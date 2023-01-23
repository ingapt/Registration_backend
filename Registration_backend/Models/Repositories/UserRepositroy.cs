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

        public bool AddUser(UserData userData)
        {
            if (userData != null)
            {
                User user = new User()
                {
                    UserName = userData.UserName,
                    Password = userData.Password,
                    Role = userData.Role,
                };

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public User GetUserById(int id)
        {
            var user = _dbContext.Users.Find(id);

            return user;
        }

        public bool UpdateUser(int id, User updateUser)
        {
            if (updateUser != null)
            {
                var existingUser = _dbContext.Users.Find(id);

                existingUser.Role = updateUser.Role;
                existingUser.Password = updateUser.Password;

                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteUser(int id)
        {
            var existingUser = _dbContext.Users.Find(id);

            if (existingUser == null)
            {
                return false;
            }

            _dbContext.Users.Remove(existingUser);
            _dbContext.SaveChangesAsync();

            return true;
        }

        public User UserLogin(User user)
        {
            var existingUser = _dbContext.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).SingleOrDefault();

            return existingUser;
        }
    }
}
