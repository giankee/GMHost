using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models.Mantenimiento
{
    public class gm_tareaAccion
    {
        [Key]
        public int idTareaAccion { get; set; }

        [Required]
        public int intervaloTareaId { get; set; }

        [Required]
        public int accionId { get; set; }

        [Required]
        public bool estadoActivado { get; set; }

        public gm_accionM accion { get; set; }

        public gm_intervaloTarea intervaloTarea { get; set; }

    }
}
