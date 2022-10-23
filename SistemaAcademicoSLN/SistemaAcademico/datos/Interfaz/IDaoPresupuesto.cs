using SistemaAcademico.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.datos.Interfaz
{
    public interface IDaoPresupuesto
    {
        IDaoPresupuesto ObtenerInstancia(); //PROBLEMA CON EL SINGLETON
        int ObtenerProximoNro(string SP);
        DataTable ObtenerCombo(string SP);
        bool AltaLegajo(Alumno alumno);
        bool AltaInscripcion(Inscripcion objeto);


    }
}
