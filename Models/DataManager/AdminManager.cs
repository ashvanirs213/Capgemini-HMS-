using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Models.Repository;

namespace HotelManagementSystem.Models.DataManager
{
    public class AdminManager : IdataRepository<Admin>
    {
        readonly AdminDbContext _AdminContext;
        public AdminManager(AdminDbContext context)
        {
            _AdminContext = context;
        }
        public IEnumerable<Admin> GetAll()
        {
            return _AdminContext.Admins.ToList();
        }
        public Admin Get(int id)
        {
            return _AdminContext.Admins.FirstOrDefault(e => e.AdminId == id);
        }
        public void Add(Admin entity)
        {
            _AdminContext.Admins.Add(entity);
            _AdminContext.SaveChanges();
        }
        public void Delete(Admin entity)
        {
            _AdminContext.Admins.Remove(entity);
            _AdminContext.SaveChanges();
        }
        public void Update(Admin admin, Admin entity)
        {
            admin.FirstName = entity.FirstName;
            admin.LastName = entity.LastName;
            admin.Email = entity.Email;
            admin.PhoneNumber = entity.PhoneNumber;
            admin.Designation = entity.Designation;
            admin.DateOfBirth = entity.DateOfBirth;
            admin.DateOfJoin = entity.DateOfJoin;

            _AdminContext.SaveChanges();
        }
    }
}
