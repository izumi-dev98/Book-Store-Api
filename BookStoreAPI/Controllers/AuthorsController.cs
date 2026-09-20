using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.Models.Domains;
using BookStoreAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorsController(AppDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        // Gell All Authors

        [HttpGet]
        public IActionResult GellAllAuthors()
        {
            var authorsDomain = _dbContext.Authors.ToList();

            if (!authorsDomain.Any())
            {
                return NotFound();
            }

            var authosDto = _mapper.Map<List<AuthorsDTO>>(authorsDomain);

            return Ok(authosDto);
        }


        // Single Author


        [HttpGet]
        [Route("{id:int}")]

        public IActionResult AuthorById([FromRoute] int id)
        {
            var authorDomain = _dbContext.Authors.FirstOrDefault(a => a.Id == id);

            if(authorDomain is null)
            {
                return NotFound();
            }

            var author = _mapper.Map<AuthorsDTO>(authorDomain);

            return Ok(author);
        }

        // Post Create Author 

        [HttpPost]

        public IActionResult CreateAuthor([FromBody] CreateAuthorDTO createAuthorDTO)
        {
            if(createAuthorDTO is null)
            {
                return BadRequest();
            }

            var authorDomain = _mapper.Map<Authors>(createAuthorDTO);

            _dbContext.Authors.Add(authorDomain);
            _dbContext.SaveChanges();

            var authorDto = _mapper.Map<AuthorsDTO>(authorDomain);

            return CreatedAtAction(nameof(AuthorById), new { id = authorDomain.Id }, authorDto);
        }


        // Put Method 

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult UpdateAuthor([FromBody] UpdateAuthorDTO updateAuthorDTO ,[FromRoute] int id)
        {

            var authorDomin = _dbContext.Authors.Find(id);

            if(authorDomin is null)
            {
                return NotFound();
            }

            _mapper.Map(updateAuthorDTO,authorDomin);
            _dbContext.SaveChanges();

            return NoContent();
        }


        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteAuthor([FromRoute] int id)
        {

            var authorDomain = _dbContext.Authors.Find(id);

            if(authorDomain is null)
            {
                return NotFound();
            }

            _dbContext.Authors.Remove(authorDomain);
            _dbContext.SaveChanges();


            return Ok($"Author {authorDomain.Id} and {authorDomain.Name} Delete is Successful");
        }
    }
}
