using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iluminada.Web.Entidad
{
    public class Tabla
    {
        public string NombreTabla { get; set; }
        public int Codigo { get; set; }
        public string Valor { get; set; }
        public int? CodigoPadre { get; set; }
        public bool EsActivo { get; set; }


        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
    }
}