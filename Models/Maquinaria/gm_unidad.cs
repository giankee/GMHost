using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models
{
    public class gm_unidad
    {
        [Key]
        public int idUnidad { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string simbolo { get; set; }

        public int estado { get; set; }

        public int magnitudId { get; set; }

        public gm_magnitud magnitud { get; set; }
    }
}
