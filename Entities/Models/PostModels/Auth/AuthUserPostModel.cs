using Entity.Enums;
using System.ComponentModel.DataAnnotations;

namespace Entity.Models.PostModels.Auth
{
    public class AuthUserPostModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите имя пользователя")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пожалуйста, подтвердите пароль")]
        public string ConfirmPassword { get; set; }
        public string Description { get; set; }
        public AdmUserStatus Status { get; set; }
        public int? OrgId { get; set; }
    }
}
