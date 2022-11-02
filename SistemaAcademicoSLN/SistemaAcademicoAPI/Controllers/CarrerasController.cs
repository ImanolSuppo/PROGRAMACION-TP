using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.dominio;
using SistemaAcademico.fachada;
using System.Collections.Generic;
using System.Data;

namespace SistemaAcademicoAPI.Controllers
{
    public class CarrerasController : Controller
    {
        private IDataApi dataApi;
        public CarrerasController()
        {
            dataApi = new DataApi();
        }
        // GET: CarrerasController
        [HttpGet("/Carreras")]
        public ActionResult GetCombo()
        {
            DataTable dataTable = null;
            try
            {
                dataTable = dataApi.GetCombo("SP_Consultar_carreras");
                List<Carrera> lst = dataApi.ObtenerCarrera(dataTable);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        // GET: CarrerasController/Details/5
        public ActionResult GetComboId(int id)
        {
            DataTable dataTable = null;
            try
            {
                dataTable = dataApi.GetCombo("SP_Consultar_carreras");
                List<Carrera> lst = dataApi.ObtenerCarrera(dataTable);
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst[i].Id==id)
                        return Ok(lst[i]);
                }
                return BadRequest("No se encuentra la carrera con id: "+ id.ToString());

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

    }
}
