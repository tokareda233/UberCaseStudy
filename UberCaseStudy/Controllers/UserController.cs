using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberCaseStudy.DTO.User;
using UberCaseStudy.UnitOfWork;

namespace UberCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }


        [HttpGet("Drivers")]
        public async Task<IActionResult> GetAllDrivers()
        {
            var d=await _unit.Users.GetAllDrivers();
            var dto =_mapper.Map<List<GetUserDTO>>(d);

            return Ok(dto);
        }


        [HttpGet("Search")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var d = await _unit.Users.SearchByName(name);
            var dto = _mapper.Map<List<GetUserDTO>>(d);

            return Ok(dto);
        }

    }
}
