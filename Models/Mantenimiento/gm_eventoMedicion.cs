using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models.Mantenimiento
{
    public class gm_eventoMedicion
    {
        [Key]
        public int idEventoMedicion { get; set; }

        [Required]
        public int intervaloId { get; set; }

        [Required]
        public int eventoId { get; set; }

        public int medicionId { get; set; }
        
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? valor { get; set; }

        public gm_medicionM medicion { get; set; }

        public gm_eventoM evento { get; set; }

        public gm_intervaloM intervalo { get; set; }
    }
}
