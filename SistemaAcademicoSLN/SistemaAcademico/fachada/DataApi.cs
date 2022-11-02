using SistemaAcademico.datos;
using SistemaAcademico.dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.fachada
{
    public class DataApi : IDataApi
    {
        IDao dao;
        public DataApi()
        {
            dao = new Dao();
        }
        public DataTable GetCombo(string SP)
        {
            return dao.ObtenerCombo(SP, null);
        }
        public List<Carrera> ObtenerCarrera(DataTable table)
        {
            return dao.ObtenerListaCarrera(table);
        }
    }
}
