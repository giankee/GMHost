using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models
{
    public class gm_magnitud
    {
        [Key]
        public int idMagnitud{ get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string nombre { get; set; }

        public int estado { get; set; }

        public ICollection<gm_unidad> listUnidad { get; set; }
    }
}
