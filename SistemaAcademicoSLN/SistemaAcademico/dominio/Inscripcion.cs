using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class Inscripcion
    {
        public List<DetalleInscripcion> detalleInscripcions { get; set; }
        public Alumno alumno { get; set; }
        public DateTime fecha { get; set; }
        public int curso { get; set; }
        //public Inscripcion(List<DetalleInscripcion> detalleInscripcions, Alumno alumno, DateTime fecha, int curso)
        //{
        //    DetalleInscripcions = detalleInscripcions;
        //    Alumno = alumno;
        //    Fecha = fecha;
        //    Curso = curso;
        //}
        public Inscripcion()
        {
            detalleInscripcions = new List<DetalleInscripcion>();
            alumno = new Alumno();
        }
        public void AgregarDetalle(DetalleInscripcion detalle)
        {
            detalleInscripcions.Add(detalle);
        }
        public void EliminarDetalle(int indice)
        {
            detalleInscripcions.RemoveAt(indice);
        }
    }
}
