using System.ComponentModel.DataAnnotations;

namespace AdvancedIdentity.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
