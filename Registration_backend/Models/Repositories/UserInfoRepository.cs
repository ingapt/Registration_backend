using Registration_backend.Data;
using Registration_backend.Models.Entities;
using Registration_backend.Models.Interfaces;

namespace Registration_backend.Models.Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private ApplicationDbContext _dbContext;

        public UserInfoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<UserInfo> Get()
        {
            List<UserInfo> usersInfo = _dbContext.UsersInfo.ToList();
            return usersInfo;
        }

        public bool AddUserInfo(int userId, UserInfoData data)
        {
            if (data != null)
            {
                var userInfo = new UserInfo()
                {
                    UserInfoOfUserId =userId,
                    Photo = Convert.FromBase64String(data.PhotoData),
                    Name = data.Name,
                    Surname = data.Surname,
                    PersonalCode = data.PersonalCode,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email,
                };

                _dbContext.UsersInfo.Add(userInfo);
                _dbContext.SaveChanges();

                return true;
            }
            return false;
        }

        public UserInfo GetUserInfoById(int userId)
        {
            var userInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.UserInfoOfUserId == userId);

            return userInfo;
        }

        public bool UpdateUserInfo(int userId, UserInfo updateUserInfo)
        {
            if (updateUserInfo != null)
            {
                var existingUserInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.UserInfoOfUserId == userId);

                //   existingUserInfo.Photo = updateUserInfo.Photo;
                existingUserInfo.Name = updateUserInfo.Name;
                existingUserInfo.Surname = updateUserInfo.Surname;
                existingUserInfo.PersonalCode = updateUserInfo.PersonalCode;
                existingUserInfo.PhoneNumber = updateUserInfo.PhoneNumber;
                existingUserInfo.Email = updateUserInfo.Email;

                _dbContext.SaveChanges();

                return true;
            }
            return false;
        }

        public bool DeleteUserInfo(int userId)
        {
            var existingUserInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.UserInfoOfUserId == userId);

            if (existingUserInfo == null)
            {
                return false;
            }

            _dbContext.UsersInfo.Remove(existingUserInfo);
            _dbContext.SaveChangesAsync();

            return true;
        }

        public bool AddUserInfo(int userId, UserInfo data)
        {
            throw new NotImplementedException();
        }
    }
}
