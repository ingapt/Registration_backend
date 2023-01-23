using Registration_backend.Models.Entities;

namespace Registration_backend.Models.Interfaces
{
    public interface IUserRepository
    {
        List<User> Get();
        User GetUserById(int id);
        bool AddUser(UserData userData);

        bool UpdateUser(int id, User updateUser);

        bool DeleteUser(int id);

        User UserLogin(User user);
    }
}
