using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models
{
    public class gm_planMantenimiento
    {
        [Key]
        public int idPlanMantenimiento { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string nombre { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string fechaCreacion { get; set; }

        public int estado { get; set; }

        /**[Required]
        [Column(TypeName = "varchar(15)")]
        public string tipoMaquinaria { get; set; }*/

        public ICollection<gm_intervaloM> listIntervalo { get; set; }
    }
}
