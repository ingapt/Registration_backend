using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Registration_backend.Models.Entities
{
    public class UserInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
                
        public int? UserInfoOfUserId { get; set; }
        public virtual User User { get; set; }

        public virtual Address Address { get; set; }
    }
}
