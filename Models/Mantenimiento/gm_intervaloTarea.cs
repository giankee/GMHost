using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebappGM_API.Models.Mantenimiento;

namespace WebappGM_API.Models
{
    public class gm_intervaloTarea
    {
        [Key]
        public int idIntervaloTarea { get; set; }

        public int intervaloId { get; set; }

        public int tareaId { get; set; }

        public bool estadoActivado { get; set; }

        public gm_tareaM tarea { get; set; }

        public gm_intervaloM intervalo { get; set; }

        public ICollection<gm_tareaAccion> listTareaAccion { get; set; }
    }
}
