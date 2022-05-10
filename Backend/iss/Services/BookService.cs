using iss.Data;
using iss.Interfaces;
using iss.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iss.Services
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }

        public async Task<BookModel> AddBook(BookModel book)
        {
            var duplicateBook = await _context.Books.Where(x => x.BookId == book.BookId).FirstOrDefaultAsync();
            if (duplicateBook is not null)
            {
                throw new("Book is already in the database");
            }

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null)
            {
                throw new("Book not found");
            }
            _context.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<BookModel> GetBook(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<BookModel> UpdateBook(BookModel book)
        {
            var foundBook = await _context.Books.FirstOrDefaultAsync(x => x.BookId == book.BookId);
            if (foundBook is null)
                throw new Exception("Book not found");

            foundBook.BookCode = book.BookCode;
            foundBook.BookName = book.BookName;
            foundBook.Genre = book.Genre;
            foundBook.Author = book.Author;
            foundBook.BookBorrowedByUsers = book.BookBorrowedByUsers;


            await _context.SaveChangesAsync();
            return foundBook;
        }
    }
}
