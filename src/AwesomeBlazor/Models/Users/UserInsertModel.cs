using System;

namespace AwesomeBlazor.Models.Users
{
    public class UserInsertModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
    }
}
