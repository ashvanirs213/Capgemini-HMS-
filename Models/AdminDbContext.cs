using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.Models
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }
    }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>().HasData(new Admin
        {
            AdminId = 1,
            FirstName = "Naman",
            LastName = "Mathur",
            Email = "naman.mathur@gmail.com",
            Designation = "Manager",
            DateOfBirth = new System.DateTime(1989, 04, 25),
            DateOfJoin = new System.DateTime(2018, 07, 1),
            PhoneNumber = "111-999-8888",
        }
            );
    }*/
}
