using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAppGM.Models;
using WebappGM_API.Models;

namespace WebAppGM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class accountController : ControllerBase
    {
        private UserManager<gm_usuario> _userManager;
        private SignInManager<gm_usuario> _singInManager;
        private readonly ApplicationSettings _appSettings;


        public accountController(UserManager<gm_usuario> userManager, SignInManager<gm_usuario> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            this._appSettings= appSettings.Value;
        }

        //POST : /api/account/Registro
        [HttpPost]
        [Route("Registro")]
        public async Task<IActionResult> PostApplicationUser(userModel gm_usuario)
        {
            var usuario = new gm_usuario()
            {
                UserName = gm_usuario.UserName,
                Email = gm_usuario.Email,
                estado = gm_usuario.estado,
                rolAsignado= gm_usuario.rolAsignado
            };
            try
            {
                var result = await _userManager.CreateAsync(usuario, gm_usuario.PasswordHash);
                await _userManager.AddToRoleAsync(usuario, gm_usuario.rolAsignado);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] gm_usuario gm_usuario)
        {
            var user = await _userManager.FindByNameAsync(gm_usuario.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, gm_usuario.PasswordHash))
            {
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UniqueName",user.UserName.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddHours(6),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.seguridad_siempre_lista)), SecurityAlgorithms.HmacSha256)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return Ok(new { message = "Username or password is incorrect." });
        }
    }
}