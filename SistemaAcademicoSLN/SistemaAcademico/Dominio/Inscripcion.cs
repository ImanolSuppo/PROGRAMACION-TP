using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Dominio
{
    internal class Inscripcion
    {
        public List<DetalleInscripcion> DetalleInscripcions { get; set; }
        public int Legajo { get; set; }
        public DateTime Fecha { get; set; }
        public int Curso { get; set; }
        public Inscripcion(List<DetalleInscripcion> detalleInscripcions, int legajo, DateTime fecha, int curso)
        {
            DetalleInscripcions = detalleInscripcions;
            Legajo = legajo;
            Fecha = fecha;
            Curso = curso;
        }
        public Inscripcion()
        {
            DetalleInscripcions = new List<DetalleInscripcion>();
            Legajo = 0;
            Fecha = DateTime.Now;
            Curso = 0;
        }
    }
}
