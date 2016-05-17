using Iluminada.Web.Common;
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

            entidad.Areas = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_AREA);
            entidad.Niveles = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_NIVEL);
            entidad.Grados = new List<Tabla>(); ;

            var competencias = new List<Tabla>();
            competencias.Add(new Tabla { Codigo = 1, Valor = "Competencia 1" });
            entidad.Competencias = competencias;

            var capacidades = new List<Tabla>();
            capacidades.Add(new Tabla { Codigo = 1, Valor = "Capacidad 1" });
            entidad.Capacidades = capacidades;

            var metodologias = new List<Tabla>();
            metodologias.Add(new Tabla { Codigo = 1, Valor = "Metodologia 1" });
            entidad.Metodologias = metodologias;

            var titulos = new List<Tabla>();
            titulos.Add(new Tabla { Codigo = 1, Valor = "Titulo 1" });
            entidad.Titulos = titulos;

            var temas = new List<Tabla>();
            temas.Add(new Tabla { Codigo = 1, Valor = "Tema 1" });
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

            entidad.Areas = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_AREA);
            entidad.Niveles = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_NIVEL);
            entidad.Grados = new List<Tabla>(); ;

            var competencias = new List<Tabla>();
            competencias.Add(new Tabla { Codigo = 1, Valor = "Competencia 1" });
            entidad.Competencias = competencias;

            var capacidades = new List<Tabla>();
            capacidades.Add(new Tabla { Codigo = 1, Valor = "Capacidad 1" });
            entidad.Capacidades = capacidades;

            var metodologias = new List<Tabla>();
            metodologias.Add(new Tabla { Codigo = 1, Valor = "Metodologia 1" });
            entidad.Metodologias = metodologias;

            var titulos = new List<Tabla>();
            titulos.Add(new Tabla { Codigo = 1, Valor = "Titulo 1" });
            entidad.Titulos = titulos;

            var temas = new List<Tabla>();
            temas.Add(new Tabla { Codigo = 1, Valor = "Tema 1" });
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

         public ActionResult Grado(int nivelId)
        {
            return Json(TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_GRADO, nivelId),
                JsonRequestBehavior.AllowGet);
        }

    }
}
