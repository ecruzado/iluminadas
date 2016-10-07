using Iluminada.Web.Common;
using Iluminada.Web.Entidad;
using Iluminada.Web.Logica;
using Iluminada.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iluminada.Web.Controllers
{
    [Authorize]
    public class ClaseController : Controller
    {
        public ActionResult Crear()
        {
            ClaseViewModel entidad = new ClaseViewModel();
            entidad.Clase = new Clase();

            entidad.Colegios = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_COLEGIO);
            entidad.Areas = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_AREA);
            entidad.Niveles = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_NIVEL);
            entidad.Grados = new List<Tabla>(); ;
            entidad.Competencias = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_COMPETENCIALV);
            entidad.Capacidades = new List<Tabla>(); ;
            entidad.Metodologias = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_METODOLOGIALV);
            entidad.Titulos = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_TITULOLV);
            entidad.Temas = new List<Tabla>();
            entidad.VirtudesGeneral = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_VIRTUDGENERAL);
            entidad.VirtudesEspecifica = new List<Tabla>();
            return View(entidad);
        }

        [HttpPost]
        public ActionResult Crear(Clase clase)
        {
            try
            {
                clase.UsuarioCreacion = "Usuario1";
                clase.FechaCreacion = DateTime.Now;
                clase.Archivo = GuardarArchivo();

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

        public ActionResult Editar(int id)
        {
            var clase = ClaseLogica.Instancia.Obtener(id);

            ClaseViewModel entidad = new ClaseViewModel();
            entidad.Clase = clase;

            entidad.Colegios = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_COLEGIO);
            entidad.Areas = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_AREA);
            entidad.Niveles = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_NIVEL);
            entidad.Grados = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_GRADO, clase.NivelId);
            entidad.Competencias = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_COMPETENCIALV);
            entidad.Capacidades = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_CAPACIDADLV, clase.CompetenciaLvId);
            entidad.Metodologias = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_METODOLOGIALV);
            entidad.Titulos = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_TITULOLV);
            entidad.Temas = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_TEMALV, clase.TituloId);
            entidad.VirtudesGeneral = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_VIRTUDGENERAL);
            entidad.VirtudesEspecifica = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_VIRTUDESPECIFICA, clase.VirtudGeneralId);

            return View("Crear", entidad);
        }

        public ActionResult Buscar()
        {
            ClaseViewModel entidad = new ClaseViewModel();
            entidad.Clase = new Clase();

            entidad.Colegios = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_COLEGIO);
            entidad.Areas = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_AREA);
            entidad.Niveles = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_NIVEL);
            entidad.Grados = new List<Tabla>(); ;
            entidad.Competencias = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_COMPETENCIALV);
            entidad.Capacidades = new List<Tabla>(); ;
            entidad.Metodologias = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_METODOLOGIALV);
            entidad.Titulos = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_TITULOLV);
            entidad.Temas = new List<Tabla>();
            entidad.VirtudesGeneral = TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_VIRTUDGENERAL);
            entidad.VirtudesEspecifica = new List<Tabla>();
            return View(entidad);
        }

        [HttpPost]
        public ActionResult Buscar(Clase clase)
        {
            var clases = ClaseLogica.Instancia.Buscar(clase);
            return Json(clases, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Grado(int nivelId)
        {
            return Json(TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_GRADO, nivelId),
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapacidadLv(int competenciaLvId)
        {
            return Json(TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_CAPACIDADLV, competenciaLvId),
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult TemaLv(int tituloLvId)
        {
            return Json(TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_TEMALV, tituloLvId),
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult VirtudEspecifica(int virtudGeneralId)
        {
            return Json(TablaLogica.Instancia.ListPorReferencia(Constantes.TABLA_VIRTUDESPECIFICA, virtudGeneralId),
                JsonRequestBehavior.AllowGet);
        }

        private string GuardarArchivo() 
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Archivos/"), fileName);
                    file.SaveAs(path);
                    return fileName;
                }
            }
            return "";
        }
    }
}
