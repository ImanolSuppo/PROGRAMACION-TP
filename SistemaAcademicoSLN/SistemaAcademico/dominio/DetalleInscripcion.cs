using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class DetalleInscripcion
    {
        public Carrera Carrera { get; set; }
        public Materia Materia { get; set; }
        public string Baja { get; set; }
        public DetalleInscripcion( Carrera carrera, Materia materia, string baja)
        {
            Carrera = carrera;
            Materia = materia;
            Baja = baja;
        }
        public DetalleInscripcion()
        {
            Carrera = new Carrera();
            Materia = new Materia();
            Baja = null;
        }
    }
}
