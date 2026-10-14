using UberCaseStudy.Models;

namespace UberCaseStudy.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllDrivers();
        Task<List<User>> SearchByName(string name);
    }
}
