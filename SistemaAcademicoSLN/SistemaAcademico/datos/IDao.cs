using SistemaAcademico.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaAcademico.datos
{
    internal interface IDao
    {
        IDao ObtenerInstancia(); 
        int ObtenerProximoNro(string SP);
        DataTable ObtenerCombo(string SP);
        bool AltaLegajo(Alumno alumno);
        bool AltaInscripcion(Inscripcion objeto);
    }
}
