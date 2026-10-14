using Microsoft.EntityFrameworkCore;
using UberCaseStudy.Data;
using UberCaseStudy.Models;
using UberCaseStudy.Repos.Interfaces;

namespace UberCaseStudy.Repos.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context) {
           _context = context;
        }
        public async Task<List<User>> GetAllDrivers()
        {
            return await _context.users.Where(c=>c.Role=="Driver").ToListAsync();   
        }

        public async Task<List<User>> SearchByName(string name)
        {
            return await _context.users.Where(c =>c.FullName.Contains(name)).ToListAsync();
        }
    }
}
