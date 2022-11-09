using SistemaAcademico.datos;
using SistemaAcademico.dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.fachada
{
    public class DataApi : IDataApi
    {
        IDao dao;
        public DataApi()
        {
            dao = new Dao();
        }
        public DataTable GetCombo(string SP, List<Parametro> parametros)
        {
            return dao.ObtenerCombo(SP, parametros);
        }
        public List<Carrera> ObtenerListaCarrera(DataTable table)
        {
            List<Carrera> lst = new List<Carrera>();
            if (table != null)
            {
                foreach (DataRow dr in table.Rows)
                {
                    //Mapear un registro a un objeto del modelo de dominio
                    int id = int.Parse(dr["id_carrera"].ToString());
                    string nombre = dr["nombre"].ToString();
                    int duracion = int.Parse(dr["duracion"].ToString());

                    Carrera aux = new Carrera(id, nombre, duracion);
                    lst.Add(aux);
                }
            }


            return lst;
        }
        public List<Materia> ObtenerListaMateria(DataTable table)
        {
            List<Materia> lst = new List<Materia>();
            if (table != null)
            {
                foreach (DataRow dr in table.Rows)
                {
                    //Mapear un registro a un objeto del modelo de dominio
                    int id = int.Parse(dr["id_materia"].ToString());
                    string nombre = dr["nombre"].ToString();
                    int profesor = int.Parse(dr["legajo"].ToString());

                    Materia aux = new Materia(id, nombre, profesor);
                    lst.Add(aux);
                }
            }


            return lst;
        }
        public List<TipoDocumento> ObtenerListaTipoDoc(DataTable table)
        {
            List<TipoDocumento> lst = new List<TipoDocumento>();
            foreach (DataRow dr in table.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                int id = int.Parse(dr["id_tipo_doc"].ToString());
                string nombre = dr["tipo_doc"].ToString();

                TipoDocumento aux = new TipoDocumento(id, nombre);
                lst.Add(aux);
            }

            return lst;
        }
        public List<Barrios> ObtenerListaBarrio(DataTable table)
        {
            List<Barrios> lst = new List<Barrios>();
            foreach (DataRow dr in table.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                int id = int.Parse(dr["id_barrio"].ToString());
                string nombre = dr["barrio"].ToString();

                Barrios aux = new Barrios(id, nombre);
                lst.Add(aux);
            }

            return lst;
        }
        public bool GuardarInscripcion(Inscripcion inscripcion)
        {
            return dao.AltaInscripcion(inscripcion);
        }

        public int ObtenerProximo(string sp)
        {
            return dao.ObtenerProximoNro(sp);
        }

        public List<Inscripcion> ObtenerListaInscripciones(DataTable table)
        {
            List<Inscripcion> lst = new List<Inscripcion>();
            if (table != null)
            {
                foreach (DataRow dr in table.Rows)
                {
                    //Mapear un registro a un objeto del modelo de dominio
                    Inscripcion aux = new Inscripcion();
                    DetalleInscripcion detalleInscripcions = new DetalleInscripcion();
                    detalleInscripcions.id_detalle = int.Parse(dr["id_detalle"].ToString());
                    detalleInscripcions.carrera.nombre = dr["carrera"].ToString();
                    detalleInscripcions.materia.nombre = dr["materia"].ToString();
                    aux.alumno.legajo = int.Parse(dr["legajo"].ToString());
                    aux.AgregarDetalle(detalleInscripcions);
                    lst.Add(aux);
                }
            }

            return lst;
        }

        public object? BajaInscripcion(int id_detalle)
        {
            return dao.BajaInscripcion(id_detalle);
        }

        public object? ActualizarUsuario(string SP, Alumno alumno)
        {
            return dao.Actualizar(SP, alumno);
        }
        public List<Alumno> ObtenerLegajos(DataTable table)
        {
            List<Alumno> lst = new List<Alumno>();
            foreach (DataRow dr in table.Rows)
            {
                //Mapear un registro a un objeto del modelo de dominio
                Alumno aux = new Alumno();
                aux.legajo = int.Parse(dr["legajo"].ToString());
                lst.Add(aux);
            }
            return lst;
        }
        public bool ConsultarLegajo(string SP, int leg)
        {
            DataTable table = dao.ConsultarLegajo(SP, leg);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public int GuardarAlumno(Persona persona)
        {
            return dao.AltaLegajo(persona);
        }

        public List<Alumno> ObtenerListaAlumnos(DataTable table)
        {
            List<Alumno> lst = new List<Alumno>();
            if (table != null)
            {
                foreach (DataRow dr in table.Rows)
                {
                    //Mapear un registro a un objeto del modelo de dominio
                    Alumno aux = new Alumno();
                    aux.legajo = int.Parse(dr["Legajo"].ToString());
                    aux.persona.nombre = dr["Nombre_Completo"].ToString();
                    aux.persona.calle = dr["Direccion"].ToString();
                    if(int.TryParse(dr["Telefono"].ToString(),out _))
                        aux.persona.telefono = int.Parse(dr["Telefono"].ToString());
                    lst.Add(aux);
                }
            }
            return lst;
        }
        public DataTable ObtenerDetalle(string v, ObtenerDetalle obtener)
        {
            return dao.ConsultarDetalle(v, obtener);
        }
    }
}