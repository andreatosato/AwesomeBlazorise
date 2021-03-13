using AwesomeBlazor.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace AwesomeBlazor.Models.Reviews
{
    public class ReviewInsertModel
    {
        [Required]
        public UserInsertModel User { get; set; } = new UserInsertModel();

        [Required]
        [Range(0, 5)]
        public int Vote { get; set; }

        [Required(ErrorMessageResourceType = typeof(Languages.AwesomeLanguages), ErrorMessageResourceName = "Required")]
        [Display(Name = "ConfirmValue", ResourceType = typeof(Languages.AwesomeLanguages))]
        public bool ConfirmValue { get; set; }
    }
}
