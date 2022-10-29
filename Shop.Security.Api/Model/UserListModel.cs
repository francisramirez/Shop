

using Shop.Security.Api.Data.Entity;

namespace Shop.Security.Api.Model
{
    public class UserListModel
    {
        public UserListModel(User user)
        {
            this.UserId = user.UserId;
            this.Email = user.Email;
            this.Name = user.Name;
            this.Password = user.Password;
        }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
