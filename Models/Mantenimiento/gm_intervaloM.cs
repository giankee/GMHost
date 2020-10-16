using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebappGM_API.Models.Mantenimiento;

namespace WebappGM_API.Models
{
    public class gm_intervaloM
    {
        [Key]
        public int idIntervaloM { get; set; }

        public int planMantenimientoId { get; set; }

        public bool estadoActivado { get; set; }

        /*Relaciones*/
        public ICollection<gm_eventoMedicion> listEventoMediciones { get; set; }

        public ICollection<gm_intervaloTarea> listTareas { get; set; }

        public gm_planMantenimiento planMantenimiento { get; set; }
    }
}
