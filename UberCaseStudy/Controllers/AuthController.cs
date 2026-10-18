using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberCaseStudy.DTO.AuthDto;
using UberCaseStudy.UnitOfWork;

namespace UberCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        public AuthController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(loginDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest("Data Invalid"); }

            var token = await _unit.AuthRepo.Login(dto);
            if (token == null) { return BadRequest("Email or password is not valid"); }

            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest("Data Invalid"); }

            var u = await _unit.AuthRepo.Register(dto);

            if (u == false) { return BadRequest("email already exist"); }

            return Created();
            // test commit 

        }
    }
}
