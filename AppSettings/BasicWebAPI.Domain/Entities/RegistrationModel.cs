using System.ComponentModel.DataAnnotations;

namespace AppSettings.BasicWebAPI.Domain.Entities {
    public class RegistrationModel {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName required")]
        public string? UserName { get; set; } //I had UerName. Needed to run a Db-migration just to correct to UserName
        [Required(ErrorMessage = "Name required")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string? Password { get; set; }
    }
}
