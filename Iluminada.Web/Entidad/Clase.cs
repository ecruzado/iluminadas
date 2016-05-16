using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iluminada.Web.Entidad
{
    public class Clase
    {
        public long ClaseId { get; set; }
        public int ColegioId { get; set; }
        public string Profesor { get; set; }
        public int AreaId { get; set; }
        public int NivelId { get; set; }
        public int GradoId { get; set; }
        public int CompetenciaLvId { get; set; }
        public int CapacidadLvId { get; set; }
        public int MetodologiaLvId { get; set; }
        public int TituloId { get; set; }
        public int TemaId { get; set; }
        public string Contenido { get; set; }
        public string Competencia { get; set; }
        public string Capacidad { get; set; }
        public string TemaContenido { get; set; }
        public int VirtudGeneralId { get; set; }
        public int VirtudEspecificaId { get; set; }
        public string Indicador { get; set; }
    }
}