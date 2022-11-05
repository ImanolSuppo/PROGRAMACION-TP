using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class Barrios
    {
        public int Id { get; set; }
        public string Barrio { get; set; }
        public Barrios(int id, string nombre)
        {
            Id = id;
            Barrio = nombre;
        }
        public Barrios()
        {
            Id = 0;
            Barrio = "";
        }
    }
    
}
