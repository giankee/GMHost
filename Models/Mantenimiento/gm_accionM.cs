using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models
{
    public class gm_accionM
    {
        [Key]
        public int idAccionM { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string nombre { get; set; }

        public int estado { get; set; }
    }
}
