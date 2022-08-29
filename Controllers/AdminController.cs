using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using HotelManagementSystem.Models.DataManager;
using HotelManagementSystem.Models.Repository;

namespace HotelManagementSystem.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IdataRepository<Admin> _dataRepository;

        public AdminController(IdataRepository<Admin> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Admin> admins = _dataRepository.GetAll();
            return Ok(admins);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id )
        {
            Admin admin = _dataRepository.Get(id);
            if (admin == null)
            {
                return NotFound("Record Not Found");
            }
            return Ok(admin);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Admin admin)
        {
            if(admin == null)
            {
                return BadRequest("Admin is Null");
            }
            _dataRepository.Add(admin);
            return CreatedAtRoute("Get", new { Id = admin.AdminId }, admin);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Admin admin = _dataRepository.Get(id);
            if (admin == null)
            {
                return NotFound("Record could not be found");
            }
            _dataRepository.Delete(admin);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Admin admin)
        {
            if(admin == null)
            {
                return BadRequest("Record is Null");
            }
            Admin adminToUpdate = _dataRepository.Get(id);
            if(adminToUpdate == null)
            {
                return NotFound("Record not Found");
            }
            _dataRepository.Update(adminToUpdate, admin);
            return NoContent();
        }
        
    }
}
