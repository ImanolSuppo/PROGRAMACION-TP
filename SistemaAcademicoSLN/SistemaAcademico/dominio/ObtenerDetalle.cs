using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class ObtenerDetalle
    {
        public int legajo { get; set; }
        public DateTime fecha_desde { get; set; }
        public DateTime fecha_hasta { get; set; }
        public ObtenerDetalle()
        {
            legajo = 0;
            fecha_desde = DateTime.Now;
            fecha_hasta = DateTime.Now;
        }
    }
}
