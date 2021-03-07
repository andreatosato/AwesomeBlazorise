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

        [Required(ErrorMessageResourceType = typeof(Languages.AwesomeLanguages), ErrorMessageResourceName = "Required")]
        [EmailAddress(ErrorMessageResourceType = typeof(Languages.AwesomeLanguages), ErrorMessageResourceName = "MailErrorMessage")]
        [Display(Name = "MailField", ResourceType = typeof(Languages.AwesomeLanguages))]
        public string Email { get; set; }
    }
}
