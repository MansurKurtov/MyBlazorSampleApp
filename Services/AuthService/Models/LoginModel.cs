using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        [StringLength(15, ErrorMessage = "Identifier too long (15 character limit).")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        [StringLength(15, ErrorMessage = "Identifier too long (15 character limit).")]
        public string Password { get; set; }        
        public string ClientId { get; set; }

    }
}
