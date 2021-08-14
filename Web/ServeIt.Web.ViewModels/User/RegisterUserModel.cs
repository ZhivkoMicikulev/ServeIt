namespace ServeIt.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    using ServeIt.Common;

    public class RegisterUserModel
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The field must be with a minimum length of 3 and a maximum length of 20.")]

        public string Username { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The field must be with a minimum length of 3 and a maximum length of 20.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The field must be with a minimum length of 3 and a maximum length of 20.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "The field must be with a minimum length of 5 and a maximum length of 10.")]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        [StringLength(10, MinimumLength = 5)]
        public string Password { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        [StringLength(10, MinimumLength = 5)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMsgForField)]
        public bool IsItOwner { get; set; }
    }
}
