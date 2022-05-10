using iss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iss.Interfaces
{
    public interface IBookService
    {
        Task<BookModel> GetBook(int id);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> AddBook(BookModel book);
        Task<BookModel> UpdateBook(BookModel book);
        Task DeleteBook(int id); 
    }
}
