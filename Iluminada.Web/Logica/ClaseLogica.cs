using Iluminada.Web.Common;
using Iluminada.Web.Data;
using Iluminada.Web.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iluminada.Web.Logica
{
    public class ClaseLogica : Singleton<ClaseLogica>
    {
        private readonly ClaseData claseData = new ClaseData();

        public Clase Obtener(long id)
        {
            return claseData.Obtener(id);
        }

        public List<Clase> Buscar(Clase claseBusqueda)
        {
            return claseData.Buscar(claseBusqueda);
        }

        public int Crear(Clase clase) 
        {
            return claseData.Crear(clase);
        }

        public int Actualizar(Clase clase)
        {
            return claseData.Actualizar(clase);
        }
    }
}