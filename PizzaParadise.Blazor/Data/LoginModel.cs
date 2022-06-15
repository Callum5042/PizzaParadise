using System.ComponentModel.DataAnnotations;

namespace PizzaParadise.Blazor.Data
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? EmailAddress { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
