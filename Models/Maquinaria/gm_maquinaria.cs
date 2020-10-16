using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebappGM_API.Models;

namespace WebAppGM.Models
{
    public class gm_maquinaria
    {
        [Key]
        public int idMaquina { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string tipoMaquinaria { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string marca { get; set; }

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string modelo { get; set; }

        public int estado { get; set; }

        public int? planMantenimientoId { get; set; }


        public gm_planMantenimiento planMantenimiento { get; set; }

        public ICollection<gm_detalleFichaM> listdetalleFichaM { get; set;}

        public ICollection<gm_barco_maquinaria> listBarcoMaquinaria { get; set; }
    } 
}
