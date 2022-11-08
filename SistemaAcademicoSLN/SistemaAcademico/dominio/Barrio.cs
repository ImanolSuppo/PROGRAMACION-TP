using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class Barrios
    {
        public int id { get; set; }
        public string barrio { get; set; }
        public Barrios(int id, string nombre)
        {
            this.id = id;
            this.barrio = nombre;
        }
        public Barrios()
        {
            id = 0;
            barrio = "";
        }
    }
    
}
