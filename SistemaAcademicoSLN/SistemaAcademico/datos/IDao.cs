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
        DataTable ConsultarLegajo(string SP, int leg);
        int AltaLegajo(Persona persona);
        bool AltaInscripcion(Inscripcion objeto);
        int BajaInscripcion(int id_detalle);
        bool Actualizar(string SP, Alumno alumno);
        DataTable ConsultarDetalle(string v, ObtenerDetalle obtener);
    }
}
