using System.ComponentModel.DataAnnotations;

namespace TW.ViewModel {
    public class ForgotPasswordViewModel {
        [Required]
        [StringLength (255)]
        public string Email { get; set; }

        [Required]
        [StringLength (255)]
        public string NomeCompleto { get; set; }

    }
}