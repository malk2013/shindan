using System.ComponentModel.DataAnnotations;

namespace Shindan.Web.Core.Authentication
{
    public class TokenRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
