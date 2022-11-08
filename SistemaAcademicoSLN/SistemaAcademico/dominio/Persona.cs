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
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Barrios barrio { get; set; }
        public string calle { get; set; }
        public int altura { get; set; } 
        public int telefono { get; set; } //que tipo de dato le ponemos(?
        public TipoDocumento tipoDocumento { get; set; }
        public int documento { get; set; } //que tipo de dato le ponemos(?
        public Persona( string nombre, string apellido, Barrios barrio, string calle, int altura, int telefono, TipoDocumento tipoDocumento, int documento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.barrio = barrio;
            this.calle = calle;
            this.altura = altura;
            this.telefono = telefono;
            this.tipoDocumento = tipoDocumento;
            this.documento = documento;
        }
        public Persona()
        {
            idPersona = 0;
            nombre = "";
            apellido = "";
            barrio = new Barrios();
            calle = "";
            altura = 0;
            telefono = 0;
            tipoDocumento = new TipoDocumento();
            documento = 0;
        }
    }
}
