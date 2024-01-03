using Microsoft.AspNetCore.Identity;

namespace Administration.Models
{
    public class UserProfile : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
