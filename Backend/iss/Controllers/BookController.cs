using iss.Interfaces;
using iss.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _bookService.GetAllBooks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            return Ok(await _bookService.GetBook(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookModel book)
        {
            return Ok(await _bookService.UpdateBook(book));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BookModel>>> DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<List<BookModel>>> AddEmployee(BookModel book)
        {
            var addedBook = await _bookService.AddBook(book);
            return Created(String.Empty, addedBook);
        }
    }
}
