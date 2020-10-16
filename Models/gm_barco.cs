using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebappGM_API.Models;

namespace WebAppGM.Models
{
    public class gm_barco
    {
        [Key]
        public int idBarco { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string nombre { get; set; }

        [Required]
        [Column(TypeName = "varchar(60)")]
        public string armador { get; set; }

        [Required]
        [Column(TypeName = "varchar(60)")]
        public string constructorB { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string lugarConstruccion { get; set; }

        [Required]
        [Column(TypeName = "varchar(7)")]
        public string anioConstruccion { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string lugarReConstruccion { get; set; }

        [Column(TypeName = "varchar(7)")]
        public string anioReConstruccion { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string numMatricula { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        public string materialCasco { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 4)")]
        public decimal eslora { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 4)")]
        public decimal manga { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 4)")]
        public decimal puntal { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 4)")]
        public decimal calado { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 4)")]
        public decimal tonelajeBruto { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 4)")]
        public decimal tonelajeNeto { get; set; }

        [Column(TypeName = "decimal(12, 4)")]
        public decimal desMaximaCarga { get; set; }

        [Required]
        [Column(TypeName = "decimal(12, 4)")]
        public decimal capacidadBodega { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string tipoBodega { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string metodoPesca { get; set; }

        public string nombreI { get; set; }

        public int estado { get; set; }

        public ICollection<gm_barco_maquinaria> listBarcoMaquinarias { get; set; }

        public ICollection<gm_galeriaArchivoBarco> listGaleriaArchivoBarcos { get; set; }
    }
}
