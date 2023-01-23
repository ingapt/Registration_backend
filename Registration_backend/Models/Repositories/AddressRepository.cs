using Registration_backend.Data;
using Registration_backend.Models.Entities;
using Registration_backend.Models.Interfaces;

namespace Registration_backend.Models.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AddressRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Address> Get()
        {
            List<Address> addresses = _dbContext.Addresses.ToList();
            return addresses;
        }

        public bool AddAddress(int userInfoId, Address data)
        {
            if (data != null)
            {
                Address address = new Address()
                {
                    City = data.City,
                    Street = data.Street,
                    HouseNumber = data.HouseNumber,
                    FlatNumber = data.FlatNumber,
                    AddressOfUserInfoId = userInfoId,
                };

                _dbContext.Addresses.Add(address);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public Address GetAddressById(int UserInfoId)
        {
            var address = _dbContext.Addresses.SingleOrDefault(x => x.AddressOfUserInfoId == UserInfoId);

            return address;
        }

        public bool UpdateAddress(int userInfoId, Address updateAddress)
        {
            if (updateAddress != null)
            {
                var existingAddress = _dbContext.Addresses.SingleOrDefault(x => x.AddressOfUserInfoId == userInfoId);

                existingAddress.City = updateAddress.City;
                existingAddress.Street = updateAddress.Street;
                existingAddress.HouseNumber = updateAddress.HouseNumber;
                existingAddress.FlatNumber = updateAddress.FlatNumber;

                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteAddress(int userInfoId)
        {
            var existingAddress = _dbContext.Addresses.SingleOrDefault(x => x.AddressOfUserInfoId == userInfoId);

            if (existingAddress == null)
            {
                return false;
            }

            _dbContext.Addresses.Remove(existingAddress);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
