using SistemaAcademico.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace SistemaAcademico.datos
{
    public class Dao : IDao
    {
        private SqlConnection cnn = Singleton.ObtenerInstancia().ObtenerConexion();
        private SqlCommand cmd;
        public int ObtenerProximoNro(string SP)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand(SP, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pOut = new SqlParameter();
            pOut.ParameterName = "@next"; //ASIGNAR PARAMETRO
            pOut.DbType = DbType.Int32;
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();
            cnn.Close();
            return (int)pOut.Value;
        }


        public DataTable ObtenerCombo(string SP, List<Parametro> parametros)
        {
            try
            {
                DataTable tabla = new DataTable();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(SP, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (Parametro oParametro in parametros)
                    {
                        cmd.Parameters.AddWithValue(oParametro.Clave, oParametro.Valor.ToString());
                    }
                }
                tabla.Load(cmd.ExecuteReader());
                cnn.Close();
                return tabla;
            }
            catch(Exception e)
            {
                cnn.Close();
                return null;
            }
        }

        public DataTable ConsultarLegajo(string SP, int leg)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(SP, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@legajo", leg);
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public int AltaLegajo(Persona persona)
        {
            int legajo = 0;
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_Insertar_persona";  //ASIGNAR SP
                cmd.CommandType = CommandType.StoredProcedure;
                //ASIGNAR PARAMETROS
                //Creamos primero la persona en la BD
                cmd.Parameters.AddWithValue("@nombre", persona.nombre);
                cmd.Parameters.AddWithValue("@apellido", persona.apellido);
                cmd.Parameters.AddWithValue("@id_barrio ", persona.barrio.id);
                cmd.Parameters.AddWithValue("@calle ", persona.calle);
                cmd.Parameters.AddWithValue("@altura ", persona.altura);
                cmd.Parameters.AddWithValue("@celular ", persona.telefono);
                cmd.Parameters.AddWithValue("@id_tipo_doc ", persona.tipoDocumento.id);
                cmd.Parameters.AddWithValue("@nro_doc ", persona.documento);
                SqlParameter pOutIdPersona = new SqlParameter();
                SqlParameter pOutLegajo = new SqlParameter();
                pOutIdPersona.ParameterName = "@nro_persona";
                pOutIdPersona.DbType = DbType.Int32;
                pOutIdPersona.Direction = ParameterDirection.Output;
                pOutLegajo.ParameterName = "@legajo";
                pOutLegajo.DbType = DbType.Int32;
                pOutLegajo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOutIdPersona);
                cmd.Parameters.Add(pOutLegajo);
                cmd.ExecuteNonQuery();
                int id_persona = (int)pOutIdPersona.Value;
                legajo = (int)pOutLegajo.Value;
                SqlCommand cmdLegajo = new SqlCommand("SP_insertar_alumno", cnn,t);
                cmdLegajo.CommandType=CommandType.StoredProcedure;
                cmdLegajo.Parameters.AddWithValue("@legajo", legajo);
                cmdLegajo.Parameters.AddWithValue("@id_persona", id_persona);
                cmdLegajo.ExecuteNonQuery();
                t.Commit();

            }
            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                legajo = 0;
            }
            finally
            {

                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return legajo;
        }

        public bool AltaInscripcion(Inscripcion objeto)
        {
            bool ok = true;
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {

                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_Insert_inscripcion";  //ASIGNAR SP
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", objeto.fecha);
                cmd.Parameters.AddWithValue("@legajo", objeto.alumno.legajo);  //ASIGNAR PARAMETROS
                cmd.Parameters.AddWithValue("@curso", objeto.curso);

                //parámetro de salida:
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@id_inscripcion"; //ASIGNAR PARAMETRO
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();

                int inscripcionNro = (int)pOut.Value;

                SqlCommand cmdDetalle;
                int detalleNro = 1;
                foreach (DetalleInscripcion item in objeto.detalleInscripcions)
                {
                    cmdDetalle = new SqlCommand("SP_Insert_detalle", cnn, t); //ASIGNAR SP
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    //ASIGNAR PARAMETROS
                    cmdDetalle.Parameters.AddWithValue("@id_inscripcion", inscripcionNro);
                    cmdDetalle.Parameters.AddWithValue("@id_carrera", item.carrera.id);
                    cmdDetalle.Parameters.AddWithValue("@id_materia", item.materia.id);
                    cmdDetalle.ExecuteNonQuery();
                    detalleNro++;
                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public int BajaInscripcion(int id_detalle)
        {
            int afectadas = 0;
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_baja_inscripcion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_detalle", id_detalle);
                afectadas = cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null) { t.Rollback(); }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();

            }
            return afectadas;
        }

        public bool Actualizar(string SP, Alumno alumno)
        {
            bool ok = true;
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = SP;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", alumno.persona.nombre);
                cmd.Parameters.AddWithValue("@apellido", alumno.persona.apellido);
                cmd.Parameters.AddWithValue("@telefono", alumno.persona.telefono);
                cmd.Parameters.AddWithValue("@tipo_doc", alumno.persona.tipoDocumento.id);
                cmd.Parameters.AddWithValue("@doc", alumno.persona.documento);
                cmd.Parameters.AddWithValue("@barrio", alumno.persona.barrio.id);
                cmd.Parameters.AddWithValue("@calle", alumno.persona.calle);
                cmd.Parameters.AddWithValue("@altura", alumno.persona.altura);
                cmd.Parameters.AddWithValue("@legajo", alumno.legajo);
                cmd.ExecuteNonQuery();

                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public DataTable ConsultarDetalle(string v, ObtenerDetalle obtener)
        {
            try
            {
                DataTable tabla = new DataTable();
                cnn.Open();
                SqlCommand cmd = new SqlCommand(v, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (obtener.legajo != 0)
                    cmd.Parameters.AddWithValue("@legajo", obtener.legajo);
                cmd.Parameters.AddWithValue("@fecha_desde", obtener.fecha_desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", obtener.fecha_hasta);
                tabla.Load(cmd.ExecuteReader());
                cnn.Close();
                return tabla;
            }
            catch (Exception e)
            {
                cnn.Close();
                return null;
            }
        }
    }
}