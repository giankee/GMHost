using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappGM_API.Models
{
    public class userModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int estado { get; set; }
        public string rolAsignado { get; set; }
    }
}
