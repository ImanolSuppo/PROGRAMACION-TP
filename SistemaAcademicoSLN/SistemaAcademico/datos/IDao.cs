using SistemaAcademico.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaAcademico.datos
{
    public interface IDao
    {
        int ObtenerProximoNro(string SP);
        DataTable ObtenerCombo(string SP, List<Parametro> values);
        List<Carrera> ObtenerListaCarrera(DataTable table);
        DataTable ConsultarLegajo(string SP, int leg);
        int AltaLegajo(Persona persona);
        bool AltaInscripcion(Inscripcion objeto);
    }
}
