using System.ComponentModel.DataAnnotations;

namespace TW.ViewModel {
    public class LoginViewModel {
        [Required]
        [StringLength (255)]
        public string Email { get; set; }

        [StringLength (255, MinimumLength = 5)]
        [Required]
        public string Senha { get; set; }
    }
}