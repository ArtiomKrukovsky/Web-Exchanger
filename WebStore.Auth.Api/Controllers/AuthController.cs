using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebStore.Auth.Api.Models;
using WebStore.Auth.Common;

namespace WebStore.Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly IOptions<AuthOptions> _authOptions;

        public AuthController(StoreDbContext context, IOptions<AuthOptions> authOptions)
        {
            _context = context;
            _authOptions = authOptions;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel request)
        {
            var user = AuthenticateUser(request.Email, request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = GenerateJWT(user);

            return Ok(new
            {
                access_token = token
            });
        }

        private Account AuthenticateUser(string email, string password)
        {
            return _context.Accounts.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        private string GenerateJWT(Account user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
