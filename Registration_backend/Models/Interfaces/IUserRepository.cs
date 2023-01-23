using Registration_backend.Models.Entities;

namespace Registration_backend.Models.Interfaces
{
    public interface IUserRepository
    {
        List<User> Get();
        User GetUser(string username);
        User AddUser(UserData userData);

        User UpdateUser(int id, UserData updateUser);

        User Update(int id, string data);

        User DeleteUser(int id);

        User UserLogin(UserData user);
    }
}
