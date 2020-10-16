using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAppGM.Models;

namespace WebappGM_API.Models
{
    public class gm_itemCategory
    {
        [Key]
        public int idItemCategory { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string nombre { get; set; }

        public int estado { get; set; }
    }
}
