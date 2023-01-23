using Registration_backend.Models.Entities;

namespace Registration_backend.Models.Interfaces
{
    public interface IAddressRepository
    {
        List<Address> Get();
        Address GetAddressById(int UserInfoId);
        bool AddAddress(int userInfoId, Address data);

        bool UpdateAddress(int userInfoId, Address updateAddress);

        bool DeleteAddress(int userInfoId);
    }
}
