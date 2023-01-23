using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration_backend.Data;
using Registration_backend.Models.Entities;
using Registration_backend.Models.Interfaces;

namespace Registration_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("all")]
        public ActionResult<List<User>> Get()
        {
            List<User> users = userRepository.Get();
            return users == null ? NotFound() : Ok(users);

        }

        [HttpGet("user")]
        public ActionResult<User> GetUser([FromQuery] string username)
        {
            User user = userRepository.GetUser(username);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public ActionResult<User> UserLogin([FromQuery] string username, [FromQuery] string password)
        {
            var userData = new UserData { Password = password, Username=username};

            var user = userRepository.UserLogin(userData);

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> AddUser([FromBody] UserData userData)
        {
            if (userData == null)
            {
                return NotFound();
            }

            return Ok(userRepository.AddUser(userData));
        }

        [HttpPut]
        public ActionResult<User> UpdateUser([FromQuery] int id, [FromBody] UserData updateUser)
        {
            if (updateUser == null)
            {
                return NotFound();
            }

            var user = userRepository.UpdateUser(id, updateUser);
            
            return Ok(user);
        }

        [HttpPut("Role")]
        public ActionResult<User> Update([FromQuery] int id, [FromQuery] string value)
        { 
            var user = userRepository.Update(id, value);

            if (user == null)
            { 
                NotFound(); 
            }

            return Ok(user);
        }

        [HttpDelete]
        public ActionResult<User> DeleteUser([FromQuery] int id)
        {
            var user = userRepository.DeleteUser(id);

            if (user == null)
            { 
                return NotFound();
            }


            return Ok(user);
        }
    }
}
