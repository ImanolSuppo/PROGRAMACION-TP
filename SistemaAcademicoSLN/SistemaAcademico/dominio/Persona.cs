using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.dominio
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Barrios Barrio { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; } 
        public int Telefono { get; set; } //que tipo de dato le ponemos(?
        public TipoDocumento TipoDocumento { get; set; }
        public int Documento { get; set; } //que tipo de dato le ponemos(?
        public Persona( string nombre, string apellido, Barrios barrio, string calle, int altura, int telefono, TipoDocumento tipoDocumento, int documento)
        {
            Nombre = nombre;
            Apellido = apellido;
            Barrio = barrio;
            Calle = calle;
            Altura = altura;
            Telefono = telefono;
            TipoDocumento = tipoDocumento;
            Documento = documento;
        }
        public Persona()
        {
            IdPersona = 0;
            Nombre = "";
            Apellido = "";
            Barrio = new Barrios();
            Calle = "";
            Altura = 0;
            Telefono = 0;
            TipoDocumento = new TipoDocumento();
            Documento = 0;
        }
    }
}
