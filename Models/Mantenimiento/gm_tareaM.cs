using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models
{
    public class gm_tareaM
    {
        [Key]
        public int idTareaM { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string nombre { get; set; }

        public int estado { get; set; }
    }
}
