using Microsoft.EntityFrameworkCore;

namespace RegistrationIS_Tests
{
    public class Tests
    {
        DbContextOptions<_dbContext> options = new DbContextOptions<_dbContext>().UseSqlServer("Data Source=INGIUX\\SQLEXPRESS;Initial Catalog = RegistrationDb; Uid=ingapt; Pwd=pavasaris1985;;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}