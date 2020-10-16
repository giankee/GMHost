using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebappGM_API.Models;

namespace WebAppGM.Models
{
    public class gm_detalleFichaM
    {
        [Key]
        public int idDetalleFichaM { get; set; }

        [Required]
        public int maquinariaId { get; set; }

        public int itemId { get; set; }
        public int estado { get; set; }

        public gm_item item { get; set; }

        public gm_maquinaria maquinaria { get; set; }

        public ICollection<gm_detalleCollection> listDetalleCollection { get; set; }

    }
}
