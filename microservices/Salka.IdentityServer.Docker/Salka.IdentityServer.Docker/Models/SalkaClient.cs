using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models
{
    public class SalkaClient : IdentityUser
    {
        public string Bandname { get; set; }
        public int RecordingStudioId { get; set; }
        public int AddressId { get; set; }
    }
}