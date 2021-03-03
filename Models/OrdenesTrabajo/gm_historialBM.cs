using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAppGM.Models;
using WebappGM_API.Models.OrdenesTrabajo;

namespace WebappGM_API.Models.OrdenesTrabajoB
{
    public class gm_historialBM
    {
        [Key]
        public int idHistorialBM { get; set; }

        [Required]
        public int barcoMaquinariaId { get; set; }

        [Required]
        public int tareaMId { get; set; }

        public int? intervaloId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string periodoVigente { get; set; }

        public gm_barco_maquinaria barcoMaquinaria { get; set; }

        public ICollection<gm_historialTaOrden> listHistoTaOrdenes { get; set; }
    }
}
