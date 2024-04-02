using BL.Abstractions.Interfaces;
using BL.DTOs;
using DL.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;


        public UserController(
            IUserRepo userRepo,
            IRoleRepo roleRepo
            )
        {
            _userRepo = userRepo;
        }

        //[HttpPost]
        //public IActionResult Register([FromBody] AddUserDTO request)
        //{
        //    _userRepo.AddUser(request);

        //    return Ok("I'm alive");
        //}
    }
}
