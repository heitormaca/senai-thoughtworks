using System.ComponentModel.DataAnnotations;

namespace TW.ViewModel
{
    public class PasswordUpdateViewModel
    {
        [Required]
        public string Senha { get; set; }
    }
}