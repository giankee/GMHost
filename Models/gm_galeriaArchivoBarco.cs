using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAppGM.Models;

namespace WebappGM_API.Models
{
    public class gm_galeriaArchivoBarco
    {
        [Key]
        public int idGaleriaGeneral { get; set; }

        public int barcoId { get; set; }

        public int? barcoMaquinariaId { get; set; }

        [Required]
        public string nombreArchivo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string tipoArchivo { get; set; }

        [Required]
        public string rutaArchivo { get; set; }

        public gm_barco barco { get; set; }
    }
}
