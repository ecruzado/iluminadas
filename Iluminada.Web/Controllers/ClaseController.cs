using Iluminada.Web.Entidad;
using Iluminada.Web.Logica;
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
        // GET: /Clase/Create
        public ActionResult Crear()
        {
            ClaseViewModel entidad = new ClaseViewModel();
            entidad.Clase = new Clase();

            var areas = new List<Tabla>();
            areas.Add(new Tabla { TablaId = 1, Valor = "Area 1" });
            entidad.Areas = areas;

            var niveles = new List<Tabla>();
            niveles.Add(new Tabla { TablaId = 1, Valor = "Nivel 1" });
            entidad.Niveles = niveles;

            var grados = new List<Tabla>();
            grados.Add(new Tabla { TablaId = 1, Valor = "Grado 1" });
            entidad.Grados = grados;

            var competencias = new List<Tabla>();
            competencias.Add(new Tabla { TablaId = 1, Valor = "Competencia 1" });
            entidad.Competencias = competencias;

            var capacidades = new List<Tabla>();
            capacidades.Add(new Tabla { TablaId = 1, Valor = "Capacidad 1" });
            entidad.Capacidades = capacidades;

            var metodologias = new List<Tabla>();
            metodologias.Add(new Tabla { TablaId = 1, Valor = "Metodologia 1" });
            entidad.Metodologias = metodologias;

            var titulos = new List<Tabla>();
            titulos.Add(new Tabla { TablaId = 1, Valor = "Titulo 1" });
            entidad.Titulos = titulos;

            var temas = new List<Tabla>();
            temas.Add(new Tabla { TablaId = 1, Valor = "Tema 1" });
            entidad.Temas = temas;

            return View(entidad);
        }

        //
        // POST: /Clase/Create

        [HttpPost]
        public ActionResult Crear(Clase clase)
        {
            try
            {
                if (clase.ClaseId == 0)
                {
                    ClaseLogica.Instancia.Crear(clase);
                }
                else 
                {
                    ClaseLogica.Instancia.Actualizar(clase);
                }
                return RedirectToAction(string.Format("Editar/{0}", clase.ClaseId));
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Clase/Edit/5

        public ActionResult Editar(int id)
        {
            var clase = ClaseLogica.Instancia.Obtener(id);

            ClaseViewModel entidad = new ClaseViewModel();
            entidad.Clase = clase;

            var areas = new List<Tabla>();
            areas.Add(new Tabla { TablaId = 1, Valor = "Area 1" });
            entidad.Areas = areas;

            var niveles = new List<Tabla>();
            niveles.Add(new Tabla { TablaId = 1, Valor = "Nivel 1" });
            entidad.Niveles = niveles;

            var grados = new List<Tabla>();
            grados.Add(new Tabla { TablaId = 1, Valor = "Grado 1" });
            entidad.Grados = grados;

            var competencias = new List<Tabla>();
            competencias.Add(new Tabla { TablaId = 1, Valor = "Competencia 1" });
            entidad.Competencias = competencias;

            var capacidades = new List<Tabla>();
            capacidades.Add(new Tabla { TablaId = 1, Valor = "Capacidad 1" });
            entidad.Capacidades = capacidades;

            var metodologias = new List<Tabla>();
            metodologias.Add(new Tabla { TablaId = 1, Valor = "Metodologia 1" });
            entidad.Metodologias = metodologias;

            var titulos = new List<Tabla>();
            titulos.Add(new Tabla { TablaId = 1, Valor = "Titulo 1" });
            entidad.Titulos = titulos;

            var temas = new List<Tabla>();
            temas.Add(new Tabla { TablaId = 1, Valor = "Tema 1" });
            entidad.Temas = temas;

            return View("Crear", entidad);
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
