using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Legajo { get; set; }
        public Materia(int id, string nombre, int legajo)
        {
            Id = id;
            Nombre = nombre;
            Legajo = legajo;
        }
        public Materia()
        {
            Id = 0;
            Nombre = "";
            Legajo = 0;
        }
    }
}
