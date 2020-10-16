using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebappGM_API.Models;

namespace WebAppGM.Models
{
    public class gm_item
    {
        [Key]
        public int idItem { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(25)")]
        public string nombre { get; set; }

        public int estado { get; set; }

        //relaciones
        public int magnitudId { get; set; }

        public gm_magnitud magnitud { get; set; }

        //coleccion
        public ICollection<gm_item_identidad> listItem_identidad { get; set; }

        public ICollection<gm_item_itemCategory> listItem_itemCategory { get; set; }

        

    }
}
