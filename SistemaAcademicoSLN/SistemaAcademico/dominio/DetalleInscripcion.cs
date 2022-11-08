using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class DetalleInscripcion
    {
        public int id_detalle { get; set; }
        public Carrera carrera { get; set; }
        public Materia materia { get; set; }
        public string baja { get; set; }
        public DetalleInscripcion(Carrera carrera, Materia materia, string baja, int id_detalle)
        {
            this.carrera = carrera;
            this.materia = materia;
            this.baja = baja;
            this.id_detalle = id_detalle;
        }
        public DetalleInscripcion()
        {
            this.carrera = new Carrera();
            this.materia = new Materia();
            baja = "false";
            id_detalle = 0;
        }
    }
}
