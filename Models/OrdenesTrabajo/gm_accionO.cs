using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models.OrdenesTrabajoB
{
    public class gm_accionO
    {
        [Key]
        public int idAccionO { get; set; }

        public int tareaOId { get; set; }

        [Required]
        public int accionId { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string nombreAccionM { get; set; }

        [Required]
        [Column(TypeName = "varchar(120)")]
        public string strIntervalos { get; set; }

        [Required]
        public bool estadoRealizado { get; set; }

        public gm_tareaO tareaO { get; set; }
    }
}
