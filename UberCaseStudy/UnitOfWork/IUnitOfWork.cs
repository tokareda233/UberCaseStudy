using UberCaseStudy.Models;
using UberCaseStudy.Repos.Interfaces;

namespace UberCaseStudy.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepo Users { get; }
        IGenericRepo<Vehicle> Vehicles { get; }
        IAuthRepo AuthRepo { get; }
        void Save();

    }
}
