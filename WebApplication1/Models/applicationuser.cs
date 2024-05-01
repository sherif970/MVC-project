using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class applicationuser:IdentityUser
    {
        public string address { get; set; }
    }
}
