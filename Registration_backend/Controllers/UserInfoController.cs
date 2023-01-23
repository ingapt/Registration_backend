using Microsoft.AspNetCore.Mvc;
using Registration_backend.Models.Entities;
using Registration_backend.Models.Interfaces;

namespace Registration_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : ControllerBase
    {
        IUserInfoRepository userInfoRepository;

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

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<UserInfo> GetUserInfoById([FromRoute] int id)
        {
            var userInfo = userInfoRepository.GetUserInfoById(id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfo);
        }

        [HttpPost]
        [Route("{id:int}")]
        public ActionResult<bool> AddUserInfo([FromRoute] int id,[FromBody] UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return NotFound();
            }

            return Ok(userInfoRepository.AddUserInfo(id, userInfo));
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<bool> UpdateUser([FromRoute] int id, [FromBody] UserInfo updateUserInfo)
        {
            if (updateUserInfo == null)
            {
                return NotFound();
            }

            var existingUser = userInfoRepository.UpdateUserInfo(id, updateUserInfo);
           
            return Ok(existingUser);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<bool> DeleteUser([FromRoute] int id)
        {
           return Ok(userInfoRepository.DeleteUserInfo(id));
        }
    }
}
