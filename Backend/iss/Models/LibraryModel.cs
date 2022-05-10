using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iss.Models
{
    public class LibraryModel
    {
        [Key]
        public int LibraryId { get; set; }

        public string Adress { get; set; }
        public bool IsReturnPoint { get; set; }
        public List<BookModel> AvailableBooks { get; set; }
    }
}
