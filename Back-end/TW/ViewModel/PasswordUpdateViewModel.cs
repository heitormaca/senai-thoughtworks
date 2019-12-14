using System.ComponentModel.DataAnnotations;

namespace TW.ViewModel {
    public class PasswordUpdateViewModel {
        [Required]
        [StringLength (255, MinimumLength = 5)]
        public string Senha { get; set; }
    }
}