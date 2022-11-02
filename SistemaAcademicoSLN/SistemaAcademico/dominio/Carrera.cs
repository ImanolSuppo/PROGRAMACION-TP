using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class Carrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Duracion { get; set; }
        public Carrera(int id, string nombre, int duracion)
        {
            Id = id;
            Nombre = nombre;
            Duracion = duracion;
        }
        public Carrera()
        {
            Id = 0;
            Nombre = "";
            Duracion = 0;
        }
    }
}
