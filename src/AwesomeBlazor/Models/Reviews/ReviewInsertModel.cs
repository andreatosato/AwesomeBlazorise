using AwesomeBlazor.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace AwesomeBlazor.Models.Reviews
{
    public class ReviewInsertModel
    {
        [Required]
        public UserInsertModel User { get; set; }

        [Required]
        [Range(0, 5)]
        public int Vote { get; set; }
    }
}
