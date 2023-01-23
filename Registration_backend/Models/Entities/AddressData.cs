namespace Registration_backend.Models.Entities
{
    public class AddressData
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
        public int? AddressOfUserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
