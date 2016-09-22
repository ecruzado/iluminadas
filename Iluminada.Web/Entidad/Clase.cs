using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Iluminada.Web.Entidad
{
    public class Clase
    {
        public long ClaseId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int ColegioId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Profesor { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int AreaId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
        public int NivelId { get; set; }
        [Required(ErrorMessage = "Campo Obligatorio")]
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
        public bool EsActivo { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public string Colegio { get; set; }
        public string Area { get; set; }
        public string Nivel { get; set; }
        public string Grado { get; set; }
        public string Archivo { get; set; }

        public string FechaCreacionFormato 
        {
            get 
            {
                if(FechaCreacion != null)
                    return FechaCreacion.ToString("dd/MM/yyyy");
                return "";
            }
        }
    }
}