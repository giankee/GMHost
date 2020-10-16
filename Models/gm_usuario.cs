using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGM.Models
{
    public class gm_usuario: IdentityUser
    {
        
        [Required]
        public int estado { get; set; }
        
        public string rolAsignado { get; set; }

    }
}
