using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iss.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Cnp { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Mobile { get; set; }
        public List<BookModel> BorrowedBooks { get; set; }
    }
}
