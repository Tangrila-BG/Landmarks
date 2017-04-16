namespace DeltaDucks.Web.Areas.Admin.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UsersViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(20,ErrorMessage = "The {0} must be at least {2} characters long."),MinLength(5)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long."), MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long."), MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}