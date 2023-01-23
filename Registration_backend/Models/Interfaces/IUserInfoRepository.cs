using Registration_backend.Models.Entities;

namespace Registration_backend.Models.Interfaces
{
    public interface IUserInfoRepository
    {
        List<UserInfo> Get();
        UserInfo GetUserInfoById(int userid);
        bool AddUserInfo(int userId, UserInfo data);

        bool UpdateUserInfo(int userId, UserInfo updateUserInfo);

        bool DeleteUserInfo(int userId);
    }
}
