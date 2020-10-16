using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models
{
    public class gm_eventoM
    {
        [Key]
        public int idEventoM { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string nombre { get; set; }

        public int estado { get; set; }

        public bool isUnique { get; set; }

        public bool isOne { get; set; }

    }
}
