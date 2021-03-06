using AwesomeBlazor.Models.Users;

namespace AwesomeBlazor.Models.Reviews
{
    public class ReviewInsertModel
    {
        public UserInsertModel User { get; set; }
        public int Vote { get; set; }
    }
}
