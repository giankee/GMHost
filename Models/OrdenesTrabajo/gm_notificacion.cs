using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models
{
    public class gm_notificacion
    {
        [Key]
        public int idNotificacion { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public int? ordenTrabajoId { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string recordatorio { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string fechaCreacion { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string emisor { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string recordatorioHasta { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string estadoProceso { get; set; }
    }
}
