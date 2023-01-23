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

        public Address GetById(int id)
        {
            var address = _dbContext.Addresses.SingleOrDefault(x => x.AddressOfUserInfoId == id);

            return address;
        }

        public Address AddAddress(AddressData data)
        {
            Address address = new Address()
            {
                City = data.City,
                Street = data.Street,
                HouseNumber = data.HouseNumber,
                FlatNumber = data.FlatNumber,
                AddressOfUserInfoId = data.AddressOfUserInfoId,
            };

            _dbContext.Addresses.Add(address);
            _dbContext.SaveChanges();

            return address;
        }

         public Address UpdateUserCity(int id, string data)
         {

            var address = _dbContext.Addresses.SingleOrDefault(x => x.AddressOfUserInfoId == id);
            if (address == null)
            {
                return null;
            }

            address.City = data;

            _dbContext.SaveChanges();

           return address;
         }

        public Address UpdateUserStreet(int id, string data)
        {

            var address = _dbContext.Addresses.SingleOrDefault(x => x.AddressOfUserInfoId == id);
            if (address == null)
            {
                return null;
            }

            address.Street = data;

            _dbContext.SaveChanges();

            return address;
        }

        public Address UpdateUserHouseNumber(int id, string data)
        {

            var address = _dbContext.Addresses.SingleOrDefault(x => x.AddressOfUserInfoId == id);
            if (address == null)
            {
                return null;
            }

            address.HouseNumber = data;

            _dbContext.SaveChanges();

            return address;
        }

        public Address UpdateUserFlatNumber(int id, string data)
        {

            var address = _dbContext.Addresses.SingleOrDefault(x => x.AddressOfUserInfoId == id);
            if (address == null)
            {
                return null;
            }

            address.FlatNumber = data;

            _dbContext.SaveChanges();

            return address;
        }

        public Address DeleteAddress(int id)
        {
            var address = _dbContext.Addresses.SingleOrDefault(x => x.AddressOfUserInfoId == id);

            if (address == null)
            {
                return null;
            }

            _dbContext.Addresses.Remove(address);
            _dbContext.SaveChanges();

            return address;
        }
    }
}
