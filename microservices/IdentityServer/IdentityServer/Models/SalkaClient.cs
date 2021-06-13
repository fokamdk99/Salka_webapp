using Microsoft.AspNetCore.Identity;

namespace IdentityProvider.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class SalkaClient : IdentityUser
    {
        public string Bandname { get; set; }
        public int RecordingStudioId { get; set; }
        public int AddressId { get; set; }
    }

}
