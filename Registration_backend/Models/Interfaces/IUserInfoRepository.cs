using Registration_backend.Models.Entities;

namespace Registration_backend.Models.Interfaces
{
    public interface IUserInfoRepository
    {
        List<UserInfo> Get();
        UserInfo GetById(int Id);
        UserInfo AddUserInfo(UserInfoData data);
        UserInfo UpdateUserName(int id, string data);
        UserInfo UpdateUserSurname(int id, string data);
        UserInfo UpdateUserPersonalCode(int id, string data);
        UserInfo UpdateUserPhoneNumber(int id, string data);
        UserInfo UpdateUserEmail(int id, string data);
        UserInfo UpdateUserPhoto(int id, UserInfoData data);
        UserInfo DeleteUserInfo(int Id);

    }
}
