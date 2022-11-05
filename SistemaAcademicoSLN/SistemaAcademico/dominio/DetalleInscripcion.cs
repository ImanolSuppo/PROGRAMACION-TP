using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class DetalleInscripcion
    {
        public Carrera carrera { get; set; }
        public Materia materia { get; set; }
        public string baja { get; set; }
        public DetalleInscripcion(Carrera carrera, Materia materia, string baja)
        {
            this.carrera = carrera;
            this.materia = materia;
            this.baja = baja;
        }
        public DetalleInscripcion()
        {
            this.carrera = new Carrera();
            this.materia = new Materia();
            baja = string.Empty;
        }
    }
}
