using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Store_Web_Api.Application.MovieOperations.Commands.CreateMovie;
using Movie_Store_Web_Api.Application.MovieOperations.Commands.DeleteMovie;
using Movie_Store_Web_Api.Application.MovieOperations.Commands.UpdateMovie;
using Movie_Store_Web_Api.Application.MovieOperations.Queries.GetMovieDetail;
using Movie_Store_Web_Api.Application.MovieOperations.Queries.GetMovies;
using Movie_Store_Web_Api.DBOperations;


namespace Movie_Store_Web_Api.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public MovieController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_context,_mapper);
            return Ok( query.Handle());
        }

        [HttpGet("id")]
        public IActionResult GetMovie(int id)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = id;
            GetMovieDetailValidator validator = new GetMovieDetailValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context, _mapper);
            command.MovieId = id;
            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id,[FromBody] UpdateMovieModel model)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context, _mapper);
            command.Model = model;
            command.MovieId=id;
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel model)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model=model;
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}
