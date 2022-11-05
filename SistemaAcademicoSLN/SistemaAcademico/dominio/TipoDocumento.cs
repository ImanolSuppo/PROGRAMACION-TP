using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Tipo_doc { get; set; }
        public TipoDocumento(int id, string tipoDoc)
        {
            Id = id;
            Tipo_doc = tipoDoc;
        }
        public TipoDocumento()
        {
            Id=0;
            Tipo_doc = "";
        }
    }
}
