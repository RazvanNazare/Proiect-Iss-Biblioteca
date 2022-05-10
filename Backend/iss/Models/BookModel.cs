using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iss.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }

        public int BookCode { get; set; }
        public bool IsAvaible { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public List<UserModel> BookBorrowedByUsers { get; set; }
    }
}
