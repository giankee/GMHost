using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models
{
    public class gm_mensaje
    {
        [Key]
        public int idMensaje { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string mensaje { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string fechaCreacion { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string emisor { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string destinatrarios { get; set; }
    }
}
