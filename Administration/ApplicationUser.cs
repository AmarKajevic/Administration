using Microsoft.AspNetCore.Identity;


namespace Administration
{
    public class ApplicationUser : IdentityUser

    {
        public string RecommenderId { get; set; }
        public int Points { get; set; }   
        public DateTime RegistrationTime { get; set; }
    }
}
