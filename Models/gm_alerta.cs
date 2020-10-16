using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models
{
    public class gm_alerta
    {
        [Key]
        public int idAlerta { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string color { get; set; }

        [Required]
        public int rangoInicio { get; set; }

        [Required]
        public int rangoFin { get; set; }

        [Required]
        public int nivelPrioridad { get; set; }

        [Required]
        public string tipoMaquinaria { get; set; }
    }
}
