using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration_backend.Data;
using Registration_backend.Models.Entities;
using Registration_backend.Models.Interfaces;

namespace Registration_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            List<User> users = userRepository.Get();
            return users == null ? NotFound() : Ok(users);

        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<User> GetUserById([FromRoute] int id)
        {
            var user = userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<bool> AddUser([FromBody] UserData userData)
        {
            if (userData == null)
            {
                return NotFound();
            }

            return Ok(userRepository.AddUser(userData));
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<bool> UpdateUser([FromRoute] int id, [FromBody] User updateUser)
        {
            if (updateUser == null)
            {
                return NotFound();
            }

            var existingUser = userRepository.UpdateUser(id, updateUser);
            return Ok(existingUser);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<bool> DeleteUser([FromRoute] int id)
        {
            return Ok(userRepository.DeleteUser(id));
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<User> UserLogin([FromBody] User user)
        {
            var existingUser = userRepository.UserLogin(user);

            if (existingUser == null)
            {
                return BadRequest("Vartotojo vardas arba slaptažodis yra neteisingi.");
            }

            return Ok(user);
        }

    }
}
