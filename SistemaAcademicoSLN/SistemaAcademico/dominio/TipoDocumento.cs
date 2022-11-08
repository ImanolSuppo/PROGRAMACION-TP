using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class TipoDocumento
    {
        public int id { get; set; }
        public string tipo_doc { get; set; }
        public TipoDocumento(int id, string tipoDoc)
        {
            this.id = id;
            this.tipo_doc = tipoDoc;
        }
        public TipoDocumento()
        {
            id=0;
            tipo_doc = "";
        }
    }
}
