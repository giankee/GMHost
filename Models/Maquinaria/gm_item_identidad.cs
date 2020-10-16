using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppGM.Models;

namespace WebappGM_API.Models
{
    public class gm_item_identidad
    {
        [Key]
        public int idItem_identidad { get; set; }

        public int itemId { get; set; }

        public int identidadMId { get; set; }

        public bool opcional { get; set; }
        public int estado { get; set; }

        public gm_item item { get; set; }

        public gm_identidadM identidadM { get; set; }
    }
}
