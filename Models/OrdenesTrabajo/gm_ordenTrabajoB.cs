using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAppGM.Models;

namespace WebappGM_API.Models.OrdenesTrabajoB
{
    public class gm_ordenTrabajoB
    {
        [Key]
        public int idOrdenT { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string titulo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string tipoMantenimiento { get; set; }

        [Required]
        public int barcoMaquinariaId { get; set; }

        [Required]
        public int valorHS { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string fechaIngreso { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string fechaFinalizacion { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string responsable { get; set;}

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string supervisor { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string descripcionSolicitud { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string estadoProceso { get; set; }

        public gm_barco_maquinaria barcoMaquinaria{ get; set; }

        public ICollection<gm_tareaO> listTareaO { get; set; }

        public ICollection<gm_galeriaArchivoOrden> listGaleriaArchivoOrdenes { get; set; }

    }
}
