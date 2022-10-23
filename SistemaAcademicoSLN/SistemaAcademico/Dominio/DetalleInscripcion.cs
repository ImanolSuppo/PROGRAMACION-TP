using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Dominio
{
    internal class DetalleInscripcion
    {
        public int Carrera { get; set; }
        public int Materia { get; set; }
        public int NotaParcial1 { get; set; }
        public int NotaParcial2 { get; set; }
        public int NotaFinal { get; set; }
        public int EstadoAcademico { get; set; }
        public DetalleInscripcion( int carrera, int materia, int notaParcial1, int notaParcial2, int notaFinal, int estadoAcademico)
        {
            Carrera = carrera;
            Materia = materia;
            NotaParcial1 = notaParcial1;
            NotaParcial2 = notaParcial2;
            NotaFinal = notaFinal;
            EstadoAcademico = estadoAcademico;
        }
        public DetalleInscripcion()
        {
            Carrera = 0;
            Materia = 0;
            NotaParcial1 = 0;
            NotaParcial2 = 0;
            NotaFinal = 0;
            EstadoAcademico = 0;
        }
    }
}
