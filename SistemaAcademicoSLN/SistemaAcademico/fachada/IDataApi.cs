using SistemaAcademico.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.fachada
{
    public interface IDataApi
    {
        DataTable GetCombo(string SP);
        List<Carrera> ObtenerListaCarrera(DataTable table);
        List<Materia> ObtenerListaMateria(DataTable table);
        List<TipoDocumento> ObtenerListaTipoDoc(DataTable table);
        List<Barrios> ObtenerListaBarrio(DataTable table);
        bool GuardarInscripcion(Inscripcion inscripcion);

    }
}
