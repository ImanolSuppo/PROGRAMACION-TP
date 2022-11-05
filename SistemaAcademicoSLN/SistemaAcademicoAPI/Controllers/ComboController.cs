using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.datos;
using SistemaAcademico.dominio;
using SistemaAcademico.fachada;
using System.Collections.Generic;
using System.Data;

namespace SistemaAcademicoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboController : Controller
    {
        private IDataApi dataApi;
        public ComboController()
        {
            dataApi = new DataApi();
        }
        // GET: CarrerasController
        [HttpGet("/Carreras")]
        public ActionResult GetComboCarrera()
        {
            DataTable dataTable = null;
            try
            {
                dataTable = dataApi.GetCombo("SP_consultar_carreras");
                List<Carrera> lst = dataApi.ObtenerListaCarrera(dataTable);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/Materias")]
        public ActionResult GetComboMateria()
        {
            DataTable dataTable = null;
            try
            {
                dataTable = dataApi.GetCombo("sp_consultar_materias");
                List<Materia> lst = dataApi.ObtenerListaMateria(dataTable);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/TipoDocumentos")]
        public ActionResult GetComboTipoDocumento()
        {
            DataTable dataTable = null;
            try
            {
                dataTable = dataApi.GetCombo("SP_CONSULTAR_TIPO_DOC");
                List<TipoDocumento> lst = dataApi.ObtenerListaTipoDoc(dataTable);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/Barrios")]
        public ActionResult GetComboBarrio()
        {
            DataTable dataTable = null;
            try
            {
                dataTable = dataApi.GetCombo("SP_CONSULTAR_BARRIOS");
                List<Barrios> lst = dataApi.ObtenerListaBarrio(dataTable);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/Proximo")]
        public ActionResult GetProximoLegajo()
        {
            int proximo;
            try
            {
                proximo = dataApi.ObtenerProximo("SP_proximo_legajo");               
                return Ok(proximo);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/Inscripcion")]
        public IActionResult CreateInscripcion(Inscripcion inscripcion)
        {
            try
            {
                if (inscripcion == null)
                {
                    return BadRequest("Datos de inscripcion incorrectos!");
                }

                return Ok(dataApi.GuardarInscripcion(inscripcion));
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/ObtenerDetalle")]
        public IActionResult GetObtenerDetalle(Inscripcion inscripcion)
        {
            DataTable dataTable = null;
            try
            {
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
