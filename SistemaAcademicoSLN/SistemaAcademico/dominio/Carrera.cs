using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class Carrera
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int duracion { get; set; }
        public Carrera(int id, string nombre, int duracion)
        {
            this.id = id;
            this.nombre = nombre;
            this.duracion = duracion;
        }
        public Carrera()
        {
            id = 0;
            nombre = "";
            duracion = 0;
        }
    }
}
