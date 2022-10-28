using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademicoForm.dominio
{
    public class Inscripcion
    {
        public List<DetalleInscripcion> DetalleInscripcions { get; set; }
        public Alumno Alumno { get; set; }
        public DateTime Fecha { get; set; }
        public int Curso { get; set; }
        public Inscripcion(List<DetalleInscripcion> detalleInscripcions, Alumno alumno, DateTime fecha, int curso)
        {
            DetalleInscripcions = detalleInscripcions;
            Alumno = alumno;
            Fecha = fecha;
            Curso = curso;
        }
        public Inscripcion()
        {
            DetalleInscripcions = new List<DetalleInscripcion>();
            Alumno = new Alumno();
            Fecha = DateTime.Now;
            Curso = 0;
        }
    }
}
