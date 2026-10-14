using UberCaseStudy.DTO.AuthDto;

namespace UberCaseStudy.Repos.Interfaces
{
    public interface IAuthRepo
    {
        Task<string> Login(loginDTO login);
        Task<bool> Register(RegisterDTO login);
    }
}
