using SistemaAcademico.datos.Interfaz;
using SistemaAcademico.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.datos.Implementacion
{
    public class PresupuestoDao : IDaoPresupuesto
    {
        private static PresupuestoDao instancia;
        private SqlConnection cnn;
        public PresupuestoDao()
        {
            cnn = new SqlConnection(""); //AREGLAR CADENA
        }
        public static IDaoPresupuesto ObtenerInstancia() //PROBLEMA CON EL SINGLETON
        {
            if (instancia == null)
                instancia = new PresupuestoDao();
            return instancia;
        }
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

        public bool AltaLegajo(Alumno alumno)
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
                //ASIGNAR PARAMETROS
                cmd.Parameters.AddWithValue("@parametro", alumno.Legajo);
                cmd.Parameters.AddWithValue("@parametro", alumno.Persona.Nombre);  
                cmd.Parameters.AddWithValue("@parametro", alumno.Persona.Apellido);
                cmd.Parameters.AddWithValue("@parametro", alumno.Persona.Barrio);
                cmd.Parameters.AddWithValue("@parametro", alumno.Persona.Calle);
                cmd.Parameters.AddWithValue("@parametro", alumno.Persona.Altura);
                cmd.Parameters.AddWithValue("@parametro", alumno.Persona.Telefono);
                cmd.Parameters.AddWithValue("@parametro", alumno.Persona.TipoDocumento);
                cmd.Parameters.AddWithValue("@parametro", alumno.Persona.Documento);


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
                cmd.Parameters.AddWithValue("@parametro", objeto.Legajo);  //ASIGNAR PARAMETROS
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




        //TODAVIA NO VAMOS A ACTUALIZAR O BORRAR DATOS

       /* public bool Actualizar(Presupuesto objeto)
        {
            bool ok = true;
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_MODIFICAR_MAESTRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parametro", objeto.Cliente);
                cmd.ExecuteNonQuery();

                SqlCommand cmdDetalle;
                int detalleNro = 1;
                foreach (Detalle item in objeto.Detalles)
                {

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
        }*/

     /*   public bool Borrar(int nro)
        {
            string sp = "SP_ELIMINAR_PRESUPUESTO";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@presupuesto_nro", nro));
            int afectadas = HelperDB.ObtenerInstancia().EjecutarSQL(sp, lst);
            return afectadas > 0;
        }

        public DataTable ObtenerAlumno(string nombre, string apellido, string SP)
        {
            DataTable tabla = new DataTable();

            cnn.Open();
            SqlCommand cmd = new SqlCommand(SP, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parametroNombre", nombre);  //INGRESAR PARAMETRO
            cmd.Parameters.AddWithValue("@parametroApellido", apellido); //INGRESAR PARAMETRO
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            return tabla;
        }

        public DataTable ObtenerReporte(DateTime desde, DateTime hasta)
        {
            string sp = "SP_REPORTE_PRODUCTOS";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde", desde));
            lst.Add(new Parametro("@fecha_hasta", hasta));
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
            return dt;
        }

        public Presupuesto ObtenerPresupuestoPorNro(int nro)
        {
            Presupuesto presupuesto = new Presupuesto();
            string sp = "SP_CONSULTAR_DETALLES_PRESUPUESTO";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@presupuesto_nro", nro));

            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
            bool primero = true;

            foreach (DataRow fila in dt.Rows)
            {
                if (primero)
                {
                    presupuesto.Cliente = fila["cliente"].ToString();
                    presupuesto.Fecha = DateTime.Parse(fila["fecha"].ToString());
                    presupuesto.Descuento = Double.Parse(fila["descuento"].ToString());
                    primero = false;
                }
                int nroProducto = int.Parse(fila["id_producto"].ToString());
                string nombre = fila["n_producto"].ToString();
                double precio = double.Parse(fila["precio"].ToString());
                Producto producto = new Producto(nroProducto, nombre, precio);
                int cantidad = int.Parse(fila["cantidad"].ToString());
                DetallePresupuesto detalle = new DetallePresupuesto(producto,cantidad);
                presupuesto.AgregarDetalle(detalle);
            
            }

            return presupuesto;
        }*/
    }
}

