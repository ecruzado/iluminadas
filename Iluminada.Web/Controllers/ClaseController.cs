using Iluminada.Web.Entidad;
using Iluminada.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iluminada.Web.Controllers
{
    public class ClaseController : Controller
    {
        //
        // GET: /Clase/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Clase/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Clase/Create

        public ActionResult Crear()
        {
            ClaseViewModel entidad = new ClaseViewModel();
            entidad.Clase = new Clase();
            var areas = new List<Tabla>();
            areas.Add(new Tabla { TablaId = 1, Valor = "Area 1" });
            entidad.Areas = areas;
            entidad.Niveles = new List<Tabla>();
            entidad.Grados = new List<Tabla>();
            entidad.Competencias = new List<Tabla>();
            entidad.Capacidades = new List<Tabla>();
            entidad.Metodologias = new List<Tabla>();
            entidad.Titulos = new List<Tabla>();
            entidad.Temas = new List<Tabla>();

            return View(entidad);
        }

        //
        // POST: /Clase/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Clase/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Clase/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Clase/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Clase/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
