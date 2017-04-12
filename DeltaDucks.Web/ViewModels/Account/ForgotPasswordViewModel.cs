using System.ComponentModel.DataAnnotations;

namespace DeltaDucks.Web.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
    }
}