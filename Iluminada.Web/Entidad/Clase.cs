using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iluminada.Web.Entidad
{
    public class Clase
    {
        public int ClaseId { get; set; }
        public int ColegioId { get; set; }
        public string Profesor { get; set; }
        public int AreaId { get; set; }
        public int NivelId { get; set; }
        public int GradoId { get; set; }
        public int CompetenciaId { get; set; }
        public int CapacidadId { get; set; }
        public int MetodologiaId { get; set; }
        public int TituloId { get; set; }
        public int TemaId { get; set; }
        public string Contenido { get; set; }
        public string Competencias { get; set; }
        public string Capacidades { get; set; }
        public string TemasYContenidos { get; set; }
        public int VirtudGeneralId { get; set; }
        public int VirtudEspecificaId { get; set; }
        public string Indicador { get; set; }
    }
}