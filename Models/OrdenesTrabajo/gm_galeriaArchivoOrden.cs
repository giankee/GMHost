using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models.OrdenesTrabajoB
{
    public class gm_galeriaArchivoOrden
    {
        [Key]
        public int idArchivo { get; set; }

        [Required]
        public int ordenTrabajoId { get; set; }

        public int? tareaOId { get; set; }

        [Required]
        public string nombreArchivo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string tipoArchivo { get; set; }

        [Required]
        public string rutaArchivo { get; set; }

        public gm_ordenTrabajoB ordenTrabajo { get; set; }
    }
}
