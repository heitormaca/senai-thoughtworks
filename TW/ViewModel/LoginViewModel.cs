using System.ComponentModel.DataAnnotations;

namespace TW.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [StringLength(255, MinimumLength = 5)]
        public string Senha { get; set; }
    }
}