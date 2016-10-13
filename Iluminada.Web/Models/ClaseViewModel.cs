using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iluminada.Web.Entidad;

namespace Iluminada.Web.Models
{
    public class ClaseViewModel
    {
        public Clase Clase { get; set; }

        public List<Tabla> Colegios { get; set; }
        public List<Tabla> Areas { get; set; }
        public List<Tabla> Niveles { get; set; }
        public List<Tabla> Grados { get; set; }
        public List<Tabla> Competencias { get; set; }
        public List<Tabla> Capacidades { get; set; }
        public List<Tabla> Metodologias { get; set; }
        public List<Tabla> Titulos { get; set; }
        public List<Tabla> Temas { get; set; }
        public List<Tabla> VirtudesGeneral { get; set; }
        public List<Tabla> VirtudesEspecifica { get; set; }

        public List<string> Profesores { get; set; }
    }
}