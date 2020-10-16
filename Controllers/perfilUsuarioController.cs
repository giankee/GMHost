using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppGM.Models;

namespace WebAppGM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class perfilUsuarioController : ControllerBase
    {
        private UserManager<gm_usuario> _userManager;
        public perfilUsuarioController(UserManager<gm_usuario> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/perfilUsuario
        public async Task<Object> GetUserProfile()
        {
            string UniqueName = User.Claims.First(c => c.Type == "UniqueName").Value;
            var user = await _userManager.FindByNameAsync(UniqueName);
            return new
            {
                user.Email,
                user.UserName,
                user.rolAsignado
            };
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "para Admin";
        }

        [HttpGet]
        [Authorize(Roles = "adminMotor")]
        [Route("ForAMotor")]
        public string GetForAMotor()
        {
            return "para admin Motor";
        }

        [HttpGet]
        [Authorize(Roles = "adminMaquina")]
        [Route("ForAMaquina")]
        public string GetForAMaquina()
        {
            return "para admin Maquina";
        }

        [HttpGet]
        [Authorize(Roles = "editorMotor")]
        [Route("ForEMotor")]
        public string GetForEMotor()
        {
            return "para editorMotor";
        }


        [HttpGet]
        [Authorize(Roles = "rb_rm")]
        [Route("ForEMaquina")]
        public string GetForEMaquina()
        {
            return "para editorMaquina";
        }
    }
}