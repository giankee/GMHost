using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebappGM_API.Models.Mantenimiento;

namespace WebappGM_API.Models.OrdenesTrabajoB
{
    public class gm_tareaO
    {
        [Key]
        public int idTareaO { get; set; }

        [Required]
        public int ordenTrabajoId { get; set; }

        [Required]
        public int tareaMId { get; set; }

        [Column(TypeName = "text")]
        public string observacion { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string reponsableTarea { get; set; }

        [Required]
        public bool estadoRealizado { get; set; }

        [Required]
        public bool isNormal { get; set; }//puede ser el nuevo cambio

        public int? notificacionId { get; set; }

        public gm_notificacion notificacion { get; set; }

        public gm_ordenTrabajoB ordenTrabajo { get; set; }

        public gm_tareaM tareaM { get; set; }

        public ICollection<gm_accionO> listAccionesRealizadaO { get; set; }
        
    }
}
