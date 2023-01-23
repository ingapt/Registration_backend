using Microsoft.EntityFrameworkCore;
using Registration_backend.Data;
using Registration_backend.Models.Entities;
using Registration_backend.Models.Repositories;

namespace RegistrationIS_Tests
{
    public class TestUserRepository
    {
        DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Data Source=INGIUX\\SQLEXPRESS;Initial Catalog = RegistrationDb; Uid=ingapt; Pwd=pavasaris1985;;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
            .Options;

        UserRepositroy userRepository;
        UserData userData;
        User AddUser;
        int id;

        [OneTimeSetUp]
        public void Setup()
        {
            ApplicationDbContext _dbContext = new ApplicationDbContext(options);
            userRepository = new UserRepositroy(_dbContext);
        }

        [SetUp]
        public void Setups()
        {
            userData = new UserData { Username = "Testuotojas", Password = "testuojam", Role = "user" };
            AddUser = userRepository.AddUser(userData);
        }

        [TearDown]
        public void TearDown()
        {
            userRepository.DeleteUser(AddUser.Id);
        }

        [Test]
        public void CheckIsNewAddedUserInTheDb()
        {
            var userActual = userRepository.GetUser(userData.Username);

            Assert.AreEqual(userActual.UserName, AddUser.UserName);
        }

        [Test]
        public void GetUserUsernameAndPassword_WhenUserWillNotBeNull()
        {
            var userActual = userRepository.UserLogin(userData);

            Assert.NotNull(userActual);
        }

        [Test]
        public void UpdateAddedUserPassword_AndThenToCheckIfItMatches()
        {
            userData.Password = "newPassword";
            var userActual = userRepository.UpdateUser(AddUser.Id, userData);

            Assert.AreEqual(AddUser.Password, userActual.Password);
        }

        [Test]
        public void UpdateAddedUserRole_AndThenToCheckIfItMatches()
        {
            userData.Role = "newRole";
            var userActual = userRepository.Update(AddUser.Id, userData.Role);

            Assert.AreEqual(AddUser.Role, userActual.Role);
        }

        [Test]
        public void DeleteAddedUserFromDb_WhenResultIsNullFromDatabase()
        {
            userRepository.DeleteUser(AddUser.Id);
            var userActual = userRepository.GetUser(userData.Username);

            Assert.IsNull(userActual);
        }

    }
}