using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class Materia
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int legajo { get; set; }
        public Materia(int id, string nombre, int legajo)
        {
            this.id = id;
            this.nombre = nombre;
            this.legajo = legajo;
        }
        public Materia()
        {
            id = 0;
            nombre = "";
            legajo = 0;
        }
    }
}
