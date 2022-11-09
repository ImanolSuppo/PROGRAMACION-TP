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
                dataTable = dataApi.GetCombo("SP_consultar_carreras",null);
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
                dataTable = dataApi.GetCombo("sp_consultar_materias", null);
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
                dataTable = dataApi.GetCombo("SP_CONSULTAR_TIPO_DOC", null);
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
                dataTable = dataApi.GetCombo("SP_CONSULTAR_BARRIOS", null);
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
        [HttpGet("/ConsultarLegajo")]
        public ActionResult GetConsultarLegajo(int legajo)
        {
            DataTable dataTable = null;
            try
            {
                bool validar = dataApi.ConsultarLegajo("SP_consultar_legajo", legajo);
                return Ok(validar);
      

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
        [HttpPost("/Alumno")]
        public IActionResult CreateAlumno(Persona persona)
        {
            try
            {
                if (persona == null)
                {
                    return BadRequest("Datos de alumno incorrectos!");
                }
                int legajo = dataApi.GuardarAlumno(persona);
                return Ok(legajo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/ObtenerDetalle")]
        public IActionResult GetObtenerDetalle(ObtenerDetalle obtener)
        {
            DataTable dataTable = null;
            try
            {
                if (obtener == null)
                {
                    return BadRequest("Datos de detalle incorrectos!");
                }
                DataTable table = dataApi.ObtenerDetalle("SP_obtener_detalles", obtener);
                List<Inscripcion> lst = dataApi.ObtenerListaInscripciones(table);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpPost("/ObtenerAlumnos")]
        public IActionResult GetObtenerAlumnos(List<Parametro> parametros)
        {
            DataTable dataTable = null;
            try
            {
                if (parametros == null)
                {
                    return BadRequest("Datos de inscripcion incorrectos!");
                }
                DataTable table = dataApi.GetCombo("SP_Obtener_Alumnos", parametros);
                List<Alumno> lst = dataApi.ObtenerListaAlumnos(table);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpDelete("/BajaInscripcion{id_detalle}")] 
        public IActionResult PutBajaInscripcion(int id_detalle)
        {
            try
            {
                if (id_detalle == null || id_detalle == 0)
                {
                    return BadRequest("Datos de inscripcion incorrectos!");
                }

                return Ok(dataApi.BajaInscripcion(id_detalle));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpPut("/ActualizarUsuario")]
        public IActionResult PutActualizar([FromBody] Alumno alumno)
        {
            try
            {
                if (alumno == null)
                {
                    return BadRequest("Datos de inscripcion incorrectos!");
                }

                return Ok(dataApi.ActualizarUsuario("SP_modificar_usuario", alumno));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/ComboLegajos")]
        public ActionResult GetComboLegajos()
        {
            DataTable dataTable = null;
            try
            {
                dataTable = dataApi.GetCombo("SP_combo_legajo", null);
                List<Alumno> lst = dataApi.ObtenerLegajos(dataTable);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
