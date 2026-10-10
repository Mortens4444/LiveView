using Database.Interfaces;
using Database.Services.PasswordHashers;
using LiveView.WebApi.Authorization;
using LiveView.WebApi.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LiveView.WebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly JwtOptions jwtOptions;

        public AuthController(IUserRepository userRepository, JwtOptions jwtOptions)
        {
            this.userRepository = userRepository;
            this.jwtOptions = jwtOptions;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request?.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest();
            }

            var user = userRepository.Login(
                UserPasswordHasher.UsernameEncrypt(request.Username),
                UserPasswordHasher.Hash(request.Password));

            if (user == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.Name, user.Username ?? string.Empty)
            };

            var expiresAt = DateTime.UtcNow.AddHours(8);
            var credentials = new SigningCredentials(jwtOptions.SigningKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: JwtOptions.Issuer,
                audience: JwtOptions.Audience,
                claims: claims,
                expires: expiresAt,
                signingCredentials: credentials);

            return Ok(new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = expiresAt
            });
        }
    }
}
