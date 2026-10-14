using AutoMapper;
using UberCaseStudy.DTO.User;
using UberCaseStudy.DTO.Vehicle;
using UberCaseStudy.Models;

namespace UberCaseStudy.Mapping
{
    public class ModelsProfile:Profile
    {
        public ModelsProfile() { 
        
            CreateMap<User,GetUserDTO> ();


            CreateMap<Vehicle, GetVehicleDTO>();
            CreateMap<CreateVehicleDTO, Vehicle>();


        }
    }
}
