using System.ComponentModel.DataAnnotations;

namespace AdvancedIdentity.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
