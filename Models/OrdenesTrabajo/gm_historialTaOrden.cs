using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebappGM_API.Models.OrdenesTrabajoB;

namespace WebappGM_API.Models.OrdenesTrabajo
{
    public class gm_historialTaOrden
    {

        [Key]
        public int idHistorialTaOrden { get; set; }

        [Required]
        public int historialBMID { get; set; }

        public int ordenTId { get; set; }

        public gm_historialBM historialBM { get; set; }

        public gm_ordenTrabajoB ordenT { get; set; }
    }
}
