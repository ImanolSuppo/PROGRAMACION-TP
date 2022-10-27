using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademicoForm.dominio
{
    public class Alumno
    {
        public int Legajo { get; set; }
        public Persona Persona { get; set; }
        public Alumno(int legajo, Persona persona)
        {
            Legajo = legajo;
            Persona = persona;
        }
        public Alumno()
        {
            Legajo = 000;
            Persona = new Persona();
        }
    }
}
