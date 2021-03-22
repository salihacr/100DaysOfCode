using System.ComponentModel.DataAnnotations;

namespace AdvancedIdentity.Models.Accounts
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
