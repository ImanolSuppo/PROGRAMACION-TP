using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class Alumno
    {
        public int legajo { get; set; }
        public Persona persona { get; set; }
        public Alumno(int legajo, Persona persona)
        {
            this.legajo = legajo;
            this.persona = persona;
        }
        public Alumno()
        {
            legajo = 000;
            persona = new Persona();
        }
    }
}
