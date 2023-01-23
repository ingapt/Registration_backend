using Microsoft.AspNetCore.Mvc;
using Registration_backend.Models.Entities;
using Registration_backend.Models.Interfaces;

namespace Registration_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepository userInfoRepository;

        public UserInfoController()
        {
            this.userInfoRepository = userInfoRepository;
        }

        [HttpGet]
        public ActionResult<List<UserInfo>> Get()
        {
            List<UserInfo> usersInfo = userInfoRepository.Get();
            return usersInfo == null ? NotFound() : Ok(usersInfo);

        }

        [HttpGet("id")]
        public ActionResult<UserInfo> GetById([FromQuery] int id)
        {
            var userInfo = userInfoRepository.GetById(id);

            if (userInfo == null)
            { 
                return null; 
            }

            return Ok(userInfo);
        }

        [HttpPost]
        public ActionResult<UserInfo> AddUserInfo([FromBody] UserInfoData data)
        {
            var userInfo = userInfoRepository.AddUserInfo(data);

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        [HttpPut("Name")]
        public ActionResult<UserInfo> UpdateUserName([FromQuery] int id, [FromQuery] string data)
        {
            var userInfo = userInfoRepository.UpdateUserName(id, data);

            if (userInfo == null)
            {
                return null;
            }

            return Ok(userInfo);
        }

        [HttpPut("Surname")]
        public ActionResult<UserInfo> UpdateUserSurname([FromQuery] int id, [FromQuery] string data)
        {
            var userInfo = userInfoRepository.UpdateUserSurname(id, data);

            if (userInfo == null)
            {
                return null;
            }

            return Ok(userInfo);
        }

        [HttpPut("PersonalCode")]
        public ActionResult<UserInfo> UpdateUserPersonalCode([FromQuery] int id, [FromQuery] string data)
        {
            var userInfo = userInfoRepository.UpdateUserPersonalCode(id, data);

            if (userInfo == null)
            {
                return null;
            }

            return Ok(userInfo);
        }

        [HttpPut("PhoneNumber")]
        public ActionResult<UserInfo> UpdateUserPhoneNumber([FromQuery] int id, [FromQuery] string data)
        {
            var userInfo = userInfoRepository.UpdateUserPhoneNumber(id, data);

            if (userInfo == null)
            {
                return null;
            }

            return Ok(userInfo);
        }

        [HttpPut("Email")]
        public ActionResult<UserInfo> UpdateUserEmail([FromQuery] int id, [FromQuery] string data)
        {
            var userInfo = userInfoRepository.UpdateUserEmail(id, data);

            if (userInfo == null)
            {
                return null;
            }

            return Ok(userInfo);
        }

        [HttpPut("PhotoData")]
        public ActionResult<UserInfo> UpdateUserPhoto([FromQuery] int id, [FromBody] UserInfoData data)
        {
            var userInfo = userInfoRepository.UpdateUserPhoto(id, data);

            if (userInfo == null)
            {
                return null;
            }

            return Ok(userInfo);
        }

        [HttpDelete]
        public ActionResult<UserInfo> DeleteUser([FromQuery] int id)
        {
           var userInfo = userInfoRepository.DeleteUserInfo(id);

            if (userInfo == null)
            {
                return null;
            }

            return Ok(userInfo);
        }
    }
}
