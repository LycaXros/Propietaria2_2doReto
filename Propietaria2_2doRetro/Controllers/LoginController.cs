using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Propietaria2_2doRetro.Data.EfCore;
using Propietaria2_2doRetro.Models;
using Propietaria2_2doRetro.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Propietaria2_2doRetro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly MDBContext _context;
        private readonly IConfiguration _config;
        //private List<LoginData> appUsers = new List<LoginData>
        //{
        //    new LoginData { FullName = "Jesus Dicent", UserName = "admin", Password = "1234", UserRole = "Admin" },
        //    new LoginData { FullName = "Test User", UserName = "user", Password = "1234", UserRole = "User" }
        //};
        public LoginController(IConfiguration config, MDBContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> FirstUser()
        {
            return await Crear(new CreateUserModel()
            {
                Direccion= "Un lugar en el mundo",
                Role = "Admin",
                email = "20181523@unapec.edu.do",
                Nombre = "Admin Jesus Dicent",
                Password = "12345abc",
                Telefono = "8299661067",
                UserName = "Administrador"

            });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginData login)
        {
            IActionResult response = Unauthorized();
            LoginData user = await AuthenticateUser(login);
            if (user != null)
            {
                var tokenString = GenerateJWTToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return response;
        }

        [NonAction]
        private async Task<LoginData> AuthenticateUser(LoginData loginCredentials)
        {
            //LoginData user = appUsers.SingleOrDefault(x => x.UserName == loginCredentials.UserName && x.Password == loginCredentials.Password);
            var data = await _context.User.SingleOrDefaultAsync(x => x.UserName == loginCredentials.UserName);

            if (!VerificarPasswordHash(loginCredentials.Password, data.password_hash, data.Password_salt))
            {
                return null;
            }

            LoginData user = new LoginData()
            {
                FullName = data.Nombre,
                UserName = data.UserName,
                Password = loginCredentials.Password,
                UserRole = data.Role
            };
            return user;
        }
        private string GenerateJWTToken(LoginData userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("fullName", userInfo.FullName.ToString()),
                new Claim("role",userInfo.UserRole),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        // POST: api/Usuarios/Crear
        [Authorize(Policy = Policies.Admin)]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CreateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var email = model.email.ToLower();

            if (await _context.User.AnyAsync(u => u.UserName == email))
            {
                return BadRequest("El email ya existe");
            }

            CrearPasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User usuario = new User
            {
                Role = model.Role,
                Nombre = model.Nombre,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                email = email,
                password_hash = passwordHash,
                Password_salt = passwordSalt,
                Activo = true,
                UserName = model.UserName

            };

            _context.User.Add(usuario);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok();
        }

        private bool VerificarPasswordHash(string password, byte[] passwordHashAlmacenado, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
            }
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
