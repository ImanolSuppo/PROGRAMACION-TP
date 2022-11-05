using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.dominio;
using SistemaAcademico.fachada;

namespace SistemaAcademicoAPI.Controllers
{
    public class TransaccionController : Controller
    {
        private IDataApi dataApi;
        public TransaccionController()
        {
            dataApi = new DataApi();
        }
        // GET: TransaccionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TransaccionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransaccionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransaccionController/Create
        /*[HttpPost("/Inscripcion")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateInscripcoin(Inscripcion inscripcion)
        {
            try
            {
                if (inscripcion == null)
                {
                    return BadRequest("Datos de presupuesto incorrectos!");
                }

                return Ok(dataApi.GuardarInscripcion(inscripcion));
            }
            catch
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }*/

        // GET: TransaccionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransaccionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransaccionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransaccionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
