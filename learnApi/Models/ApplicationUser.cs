using Microsoft.AspNetCore.Identity;

namespace learnApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
