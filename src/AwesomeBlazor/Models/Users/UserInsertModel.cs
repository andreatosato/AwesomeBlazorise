using System;
using System.ComponentModel.DataAnnotations;

namespace AwesomeBlazor.Models.Users
{
    public class UserInsertModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Required", ErrorMessageResourceType = typeof(Languages.AwesomeLanguages))]
        [EmailAddress(ErrorMessage = "MailErrorMessage", ErrorMessageResourceType = typeof(Languages.AwesomeLanguages))]
        [Display(Name = "MailField", ResourceType = typeof(Languages.AwesomeLanguages))]
        public string Email { get; set; }
    }
}
