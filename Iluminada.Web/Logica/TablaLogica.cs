using Iluminada.Web.Common;
using Iluminada.Web.Data;
using Iluminada.Web.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iluminada.Web.Logica
{
    public class TablaLogica : Singleton<TablaLogica>
    {
        private readonly TablaData tablaData = new TablaData();

        public List<Tabla> ListPorReferencia(string nombreTabla, int? codigoPadre = null)
        {
            return tablaData.ListPorReferencia(nombreTabla, codigoPadre);
        }
    }
}