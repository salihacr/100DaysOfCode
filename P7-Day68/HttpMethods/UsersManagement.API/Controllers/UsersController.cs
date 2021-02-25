using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManagement.API.Dummy;
using UsersManagement.API.Models;

namespace UsersManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private List<User> _users = DummyData.GetUsers(200);
        [HttpGet]
        public List<User> GetUsers()
        {
            return _users;
        }
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return _users.Find(user => user.Id == id);
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            _users.Add(user);
            return Ok("Saved Successfully");
        }
        [HttpPut]
        public User UpdateUser([FromBody] User user)
        {
            var editedUser = _users.Find(u => u.Id == user.Id);
            editedUser.Firstname = user.Firstname;
            editedUser.Lastname = user.Lastname;
            editedUser.Address = user.Address;
            return user;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var deletedUser = _users.Find(user => user.Id == id);
            _users.Remove(deletedUser);

            return Ok("Deleted Successfully");
        }
    }
}
