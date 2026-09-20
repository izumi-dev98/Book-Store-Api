using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models.Domains;
using BookStoreAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BooksController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        // Get All Books

        [HttpGet]

        public IActionResult GellAllBooks()
        {
            var bookDomains = _dbContext.Books.Include(b => b.Authors).ToList();

            if (!bookDomains.Any())
            {

                return NotFound();

            }

           

            var books = _mapper.Map<List<BooksDTO>>(bookDomains);


            return Ok(books);

        }


        // Single Book 

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult BookById([FromRoute] int id)
        {
            var bookdomain = _dbContext.Books.Include(b => b.Authors).FirstOrDefault(b => b.Id == id);

            if (bookdomain is null)
            {
                return NotFound();
            }

            var book = _mapper.Map<BooksDTO>(bookdomain);
            return Ok(book);
        }

        // Create book 
        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBooksDTO createBooksDTO)
        {

            var authorExists = _dbContext.Authors.Any(a => a.Id == createBooksDTO.AuthorId);

            if (!authorExists)
            {
                return BadRequest("Author ID does not exist in the database.");
            }


            var bookDomain = _mapper.Map<Books>(createBooksDTO);


            _dbContext.Books.Add(bookDomain);
            _dbContext.SaveChanges();

            var createdBook = _dbContext.Books
                        .Include(b => b.Authors)
                           .FirstOrDefault(b => b.Id == bookDomain.Id);

            var bookDto = _mapper.Map<BooksDTO>(createdBook);

            return Ok(bookDto);
        }



        // Update Books


        [HttpPut]
        [Route("{id:int}")]


        public IActionResult UpdateBook([FromBody] UpdateBooksDTO updateBooksDTO , [FromRoute] int id)
        {

            var bookDomin = _dbContext.Books.FirstOrDefault(b => b.Id == id);

            if(bookDomin == null)
            {
                return BadRequest();
            }

            _mapper.Map(updateBooksDTO, bookDomin);
            _dbContext.SaveChanges();

            return Ok(" Update Successful");
        }


        // Delete 

        [HttpDelete]
        [Route("{id:int}")]


        public IActionResult DeleteBook([FromRoute] int id)
        {

            var bookDomin = _dbContext.Books.FirstOrDefault(b=> b.Id == id);    

            if( bookDomin == null)
            {
                return BadRequest();
            }

            _dbContext.Books.Remove(bookDomin);
            _dbContext.SaveChanges();

            return Ok($"Books Id {bookDomin.Id} and {bookDomin.Title} Delete Is Successful");
        }

    }
}