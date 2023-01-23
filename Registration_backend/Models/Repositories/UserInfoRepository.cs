using Microsoft.AspNetCore.Mvc;
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

        public UserInfo GetById(int Id)
        {
            var userInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.UserInfoOfUserId == Id);

            return userInfo;
        }

        public UserInfo AddUserInfo(UserInfoData data)
        {

            var userInfo = new UserInfo()
            {
                UserInfoOfUserId = data.UserId,
                Photo = Convert.FromBase64String(data.PhotoData),
                Name = data.Name,
                Surname = data.Surname,
                PersonalCode = data.PersonalCode,
                PhoneNumber = data.PhoneNumber,
                Email = data.Email,
            };

            _dbContext.UsersInfo.Add(userInfo);
            _dbContext.SaveChanges();

            return userInfo;
        }

        public UserInfo UpdateUserName(int id, string data)
        {
            var userInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.Id == id);

            if (userInfo == null)
            {
                return null;
            }

            userInfo.Name = data;
            _dbContext.SaveChanges();

            return userInfo;
        }

        public UserInfo UpdateUserSurname(int id, string data)
        {
            var userInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.Id == id);

            if (userInfo == null)
            {
                return null;
            }

            userInfo.Surname = data;
            _dbContext.SaveChanges();

            return userInfo;
        }

        public UserInfo UpdateUserPersonalCode(int id, string data)
        {
            var userInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.Id == id);

            if (userInfo == null)
            {
                return null;
            }

            userInfo.PersonalCode = data;
            _dbContext.SaveChanges();

            return userInfo;
        }

        public UserInfo UpdateUserPhoneNumber(int id, string data)
        {
            var userInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.Id == id);

            if (userInfo == null)
            {
                return null;
            }

            userInfo.PhoneNumber = data;
            _dbContext.SaveChanges();

            return userInfo;
        }

        public UserInfo UpdateUserEmail(int id, string data)
        {
            var userInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.Id == id);

            if (userInfo == null)
            {
                return null;
            }

            userInfo.Email = data;
            _dbContext.SaveChanges();

            return userInfo;
        }

        public  UserInfo UpdateUserPhoto(int id, UserInfoData data)
        {
            var userInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.Id == id);

            if (userInfo == null)
            {
                return null;
            }

            userInfo.Photo = Convert.FromBase64String(data.PhotoData);
            _dbContext.SaveChanges();

            return userInfo;
        }

        public UserInfo DeleteUserInfo(int Id)
        {
            var userInfo = _dbContext.UsersInfo.SingleOrDefault(x => x.UserInfoOfUserId == Id);

            if (userInfo == null)
            {
                return null;
            }

            _dbContext.UsersInfo.Remove(userInfo);
            _dbContext.SaveChangesAsync();

            return userInfo;
        }
    }
}
