using Registration_backend.Data;
using Registration_backend.Models.Entities;
using Registration_backend.Models.Interfaces;

namespace Registration_backend.Models.Repositories
{
    public class UserRepositroy : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepositroy(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> Get()
        {
            List<User> users = _dbContext.Users.ToList();
            return users;
        }

        public User AddUser(UserData userData)
        {
            User user = new User()
            {
                UserName = userData.Username,
                Password = userData.Password,
                Role = userData.Role,
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        public User GetUser(string data)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserName == data);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public User UpdateUser(int id, UserData updateUser)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            user.Password = updateUser.Password;
            _dbContext.SaveChanges();

            return user;
        }

        public User Update(int id, string data)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                return null;
            }

            user.Role = data;
            _dbContext.SaveChanges();

            return user;
        }

        public User DeleteUser(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            _dbContext.Users.Remove(user);
            _dbContext.SaveChangesAsync();

            return user;
        }

        public User UserLogin(UserData user)
        {
            var existingUser = _dbContext.Users.SingleOrDefault(x => x.UserName == user.Username && x.Password == user.Password);

            if (user == null)
            {
                return null;
            }

            return existingUser;
        }
    }
}
