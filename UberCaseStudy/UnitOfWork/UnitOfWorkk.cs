using UberCaseStudy.Data;
using UberCaseStudy.Models;
using UberCaseStudy.Repos.Interfaces;

namespace UberCaseStudy.UnitOfWork
{
    public class UnitOfWorkk : IUnitOfWork
    {
        private readonly AppDbContext _contetx;
        public IAuthRepo AuthRepo { get;}

        public IUserRepo Users {  get;}

        public IGenericRepo<Vehicle> Vehicles { get;}

        public UnitOfWorkk(AppDbContext contetx,IAuthRepo authRepo,IUserRepo userRepo,IGenericRepo<Vehicle> Vehicle)
        {
            _contetx = contetx;
            AuthRepo = authRepo;
            Users = userRepo;
            Vehicles = Vehicle;
        }

       
        public void Save()
        {
            _contetx.SaveChanges();
        }
    }
}
