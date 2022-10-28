using SistemaAcademicoForm.datos;
using SistemaAcademicoForm.dominio;
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
            pOut.ParameterName = "@pOutNombre"; //ASIGNAR PARAMETRO
            pOut.DbType = DbType.Int32;
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();
            cnn.Close();

            return (int)pOut.Value;
        }

        public DataTable ObtenerCombo(string SP)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(SP, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }
        public DataTable ConsultarLegajo(string SP, int leg)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand(SP, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parametro", leg);
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
                cmd.CommandText = "SP";  //ASIGNAR SP
                cmd.CommandType = CommandType.StoredProcedure;
                //ASIGNAR PARAMETROS
                //Creamos primero la persona en la BD
                cmd.Parameters.AddWithValue("@parametro", persona.Nombre);
                cmd.Parameters.AddWithValue("@parametro", persona.Apellido);
                cmd.Parameters.AddWithValue("@parametro", persona.Barrio);
                cmd.Parameters.AddWithValue("@parametro", persona.Calle);
                cmd.Parameters.AddWithValue("@parametro", persona.Altura);
                cmd.Parameters.AddWithValue("@parametro", persona.Telefono);
                cmd.Parameters.AddWithValue("@parametro", persona.TipoDocumento);
                cmd.Parameters.AddWithValue("@parametro", persona.Documento);
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@legajo"; //ASIGNAR PARAMETRO
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();
                legajo = (int)pOut.Value;
                t.Commit();
            }
            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
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
                cmd.CommandText = "SP";  //ASIGNAR SP
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parametro", objeto.Fecha);
                cmd.Parameters.AddWithValue("@parametro", objeto.Alumno.Legajo);  //ASIGNAR PARAMETROS
                cmd.Parameters.AddWithValue("@parametro", objeto.Curso);

                //parámetro de salida:
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@parametro"; //ASIGNAR PARAMETRO
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();

                int inscripcionNro = (int)pOut.Value;

                SqlCommand cmdDetalle;
                int detalleNro = 1;
                foreach (DetalleInscripcion item in objeto.DetalleInscripcions)
                {
                    cmdDetalle = new SqlCommand("SP", cnn, t); //ASIGNAR SP
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    //ASIGNAR PARAMETROS
                    cmdDetalle.Parameters.AddWithValue("@parametro", inscripcionNro);
                    cmdDetalle.Parameters.AddWithValue("@parametro", item.Carrera);
                    cmdDetalle.Parameters.AddWithValue("@parametro", item.Materia);
                    cmdDetalle.Parameters.AddWithValue("@parametro", item.NotaParcial1);
                    cmdDetalle.Parameters.AddWithValue("@parametro", item.NotaParcial2);
                    cmdDetalle.Parameters.AddWithValue("@parametro", item.NotaFinal);
                    cmdDetalle.Parameters.AddWithValue("@parametro", item.EstadoAcademico);
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


    }
}
