using Microsoft.AspNetCore.Identity;


namespace Administration
{
    public class User : IdentityUser

    {
        public string reccomendationLink { get; set; }
    }
}
