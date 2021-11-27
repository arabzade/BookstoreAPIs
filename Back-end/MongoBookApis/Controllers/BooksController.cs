using MongoBookApis.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using MongoBookApis.Repositories;
using MongoBookApis.Dtos;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace MongoBookApis.Controllers
{
    [ApiController]
    [Route("books")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BooksController : ControllerBase
    {

        private readonly IBooksRepository repository;

        public BooksController(IBooksRepository _repository)
        {
            this.repository = _repository;
        }
        // GET /books
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = (await repository.GetBooksAsync())
                        .Select(book => book.AsDto());
            return books;
        }

        // GET /books/id
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookAsync(Guid id)
        {
            var book = await repository.GetBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            return book.AsDto();
        }
        // POST /books
        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto bookDto)
        {
            Book book = new()
            {
                Id = Guid.NewGuid(),
                Title = bookDto.Title,
                Authors = bookDto.Authors,
                AverageRating = bookDto.AverageRating,
                NumPage = bookDto.NumPage,
                RatingCount = bookDto.RatingCount,
                TextReviewCount = bookDto.TextReviewCount,
                PublicationDate = bookDto.PublicationDate,
                Publisher = bookDto.Publisher,
                CreatedDate = DateTimeOffset.UtcNow.ToString()

            };
            await repository.CreateBookAsync(book);

            return CreatedAtAction(nameof(GetBookAsync), new { Id = book.Id }, book.AsDto());
        }

        // GET /books/search
        // Parameters(optionals):
        //- title => title contains the string
        //- authors => authors contain the string
        //- minNumPage => minimum number of pages
        //- authors => maximum number of pages

        [HttpGet]
        [Route("/books/search")]
        public async Task<IEnumerable<BookDto>> SearchBook(string title = "" , string authors = "" , string minNumPage = "" , string maxNumPage = "")
        {
            var books = (await repository.SearchAsync(title,authors,minNumPage,maxNumPage))
                        .Select(book => book.AsDto());
            return books;

        }
         
    }
}
