using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAppGM.Models;

namespace WebappGM_API.Models
{
    public class gm_detalleCollection
    {
        [Key]
        public int idDetalleCollection { get; set; }

        public int detalleFichaMId { get; set; }

        public int itemCategoryId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(60)")]
        public string valor { get; set; }

        public int unidadId { get; set; }

        /*Relaciones*/
        public gm_itemCategory itemCategory { get; set; }


        public gm_detalleFichaM detalleFichaM { get; set; }
    }
}
