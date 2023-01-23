using Registration_backend.Models.Entities;

namespace Registration_backend.Models.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> Get();
        Address GetById(int id);
        Address AddAddress(AddressData data);
        Address UpdateUserCity(int id, string data);
        Address UpdateUserStreet(int id, string data);
        Address UpdateUserHouseNumber(int id, string data);
        Address UpdateUserFlatNumber(int id, string data);
        Address DeleteAddress(int id);

    }
}
