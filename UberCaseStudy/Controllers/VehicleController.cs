using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberCaseStudy.DTO.Vehicle;
using UberCaseStudy.Models;
using UberCaseStudy.UnitOfWork;

namespace UberCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public VehicleController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var v = await _unit.Vehicles.GetAll();
            var dto=_mapper.Map<List<GetVehicleDTO>>(v);
            return Ok(dto);
        
        }


        [HttpPost]
        public IActionResult Add(CreateVehicleDTO dto) {

            if (dto == null||!ModelState.IsValid) { return BadRequest(); }

            var v=_mapper.Map<Vehicle>(dto);
            _unit.Vehicles.Add(v);
            _unit.Save();
            return Created();

        }

        [HttpPut]
        public async Task<IActionResult> Update(int id ,CreateVehicleDTO dto)
        {
            if (dto == null || !ModelState.IsValid) { return BadRequest(); }

            var v = await _unit.Vehicles.GetById(id);

            if(v== null) { return BadRequest(); }


            _mapper.Map(dto, v);
            _unit.Vehicles.Update(v);
            _unit.Save();
            return Ok(dto);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var v = await _unit.Vehicles.GetById(id);

            if (v == null) { return BadRequest(); }

            _unit.Vehicles.Delete(v);
            _unit.Save();

            return NoContent();

        }

    }
}
