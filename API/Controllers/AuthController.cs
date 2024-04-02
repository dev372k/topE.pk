using API.Models;
using BL.Abstractions.Implementations;
using BL.Abstractions.Interfaces;
using BL.DTOs;
using BL.Services;
using DL.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserRepo _userRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly IEmailService _emailService;

        public AuthController(IConfiguration config,
            IUserRepo userRepo,
            IRoleRepo roleRepo,
            IEmailService emailService
            )
        {
            _config = config;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Ping()
        {
            _emailService.SendEmailAsync("smowais.neduet@gmail.com", "Test", "Testing...").GetAwaiter().GetResult();
            return Ok("I'm alive...");
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] AddUserDTO request)
        {
            _userRepo.AddUser(request);

            return Ok(new ResponseModel { Message = ResponseMessages.USER_ADDED });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO request)
        {
            var user = _userRepo.Get(request.Email, request.Password);
            return Ok(new ResponseModel { Data = new { User = user, Token = CreateToken(user) } });
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return Ok();
        }

        private string CreateToken(GetUserDTO user)
        {
            var userData = new UserData
            {
                User = user,
                Role = _roleRepo.RoleDetails(user.Role)
            };

            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(userData)),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("SecretKeys:JWT").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    public class UserData
    {
        public GetUserDTO User { get; set; }
        public List<RolePermissions> Role { get; set; }
    }
}
