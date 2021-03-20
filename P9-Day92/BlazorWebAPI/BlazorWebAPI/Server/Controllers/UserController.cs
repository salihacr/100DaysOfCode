using BlazorWebAPI.Server.Models;
using BlazorWebAPI.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlazorWebAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public ActionResult<List<User>> GetUsers()
        {
            return _context.Users.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }
        [HttpPost("")]
        public ActionResult<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(int id, User user)
        {
            var updatedUser = _context.Users.FirstOrDefault(user => user.Id == id);
            updatedUser.Name = user.Name;
            updatedUser.Email = updatedUser.Email;
            updatedUser.Password = updatedUser.Password;

            _context.SaveChanges();

            return updatedUser;
        }
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            var deletedUser = _context.Users.FirstOrDefault(user => user.Id == id);
            _context.Users.Remove(deletedUser);

            _context.SaveChanges();

        }
    }
}
