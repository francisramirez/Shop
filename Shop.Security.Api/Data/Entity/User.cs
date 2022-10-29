using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Security.Api.Data.Entity
{
    [Table("Users", Schema = "Security")]
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
