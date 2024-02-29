using System.ComponentModel.DataAnnotations;

namespace AppSettings.BasicWebAPI.Domain.Entities {
    public class LoginModel {
        public int Id { get; set; }

        [Required(ErrorMessage="UserName is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; set; }
    }
}
