using AutoMapper;
using BookStoreAPI.Data;
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
    }
}
