using SistemaAcademico.datos;
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
        DataTable GetCombo(string SP, List<Parametro> parametros);
        List<Carrera> ObtenerListaCarrera(DataTable table);
        List<Materia> ObtenerListaMateria(DataTable table);
        List<TipoDocumento> ObtenerListaTipoDoc(DataTable table);
        List<Barrios> ObtenerListaBarrio(DataTable table);
        bool GuardarInscripcion(Inscripcion inscripcion);
        int ObtenerProximo(string sp);
        List<Inscripcion> ObtenerListaInscripciones(DataTable table);
        object? BajaInscripcion(int id_detalle);
        object? ActualizarUsuario(string SP, Alumno alumno);
        List<Alumno> ObtenerLegajos(DataTable table);
        bool ConsultarLegajo(string SP, int leg);
    }
}