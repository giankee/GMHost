using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebappGM_API.Models.OrdenesTrabajoB;

namespace WebAppGM.Models
{
    public class gm_barco_maquinaria
    {
        [Key]
        public int idBarcoMaquinaria { get; set; }

        [Column(TypeName = "nvarchar(60)")]
        public string nombre { get; set; }

        [Required]
        public int barcoId { get; set; }

        public int maquinariaId { get; set; }

        [Column(TypeName = "varchar(25)")]
        public string serie { get; set; }

        [Column(TypeName = "decimal(12, 4)")]
        public decimal potencia { get; set; }

        public int unidadId { get; set; }

        public int horasServicio { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string fechaIncorporacionB { get; set; }

        [Required]
        public Boolean checkMaquinaria { get; set; }

        public int estado { get; set;}

        public string nombreI { get; set; }

        public gm_barco barco { get; set; }

        public gm_maquinaria maquinaria { get; set; }

        public ICollection<gm_historialBM> listHistorialBM { get; set; }

    }
}
