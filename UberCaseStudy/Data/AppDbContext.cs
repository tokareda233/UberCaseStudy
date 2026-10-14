using Microsoft.EntityFrameworkCore;
using UberCaseStudy.Models;

namespace UberCaseStudy.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Payment> payments { get; set; }
        public DbSet<Rating> ratings { get; set; }
        public DbSet<Ride> rides { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Vehicle>()
                .HasOne(x=>x.Driver)
                .WithOne(x=>x.Vehicle)
                .HasForeignKey<Vehicle>(x=>x.DriverId);

            modelBuilder.Entity<User>()
                .HasMany(x=>x.RidesDriver)
                .WithOne(x=>x.Driver)
                .HasForeignKey(c=>c.DriverId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany(x => x.RidesRiders)
                .WithOne(x => x.Rider)
                .HasForeignKey(c => c.RiderUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ride>()
                .HasOne(X=>X.Payment)
                .WithOne(c=>c.Ride)
                .HasForeignKey<Payment>(c=>c.RiderId);

            modelBuilder.Entity<Ride>()
               .HasOne(X => X.Rating)
               .WithOne(c => c.Ride)
               .HasForeignKey<Rating>(c => c.RiderId);




        }
    }
}
