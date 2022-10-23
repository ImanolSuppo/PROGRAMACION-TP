using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Dominio
{
    internal class Alumno
    {
        public int Legajo { get; set; }
        public Persona IdPersona { get; set; }
        public Alumno(int legajo, Persona idPersona)
        {
            Legajo = legajo;
            IdPersona = idPersona;
        }
        public Alumno()
        {
            Legajo = 000;
            IdPersona = new Persona();
        }
    }
}
