using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Store_Web_Api.Application.DirectorOperations.Commands.CreateDirector;
using Movie_Store_Web_Api.Application.DirectorOperations.Commands.DeleteDirector;
using Movie_Store_Web_Api.Application.DirectorOperations.Commands.UpdateDirector;
using Movie_Store_Web_Api.Application.DirectorOperations.Queries.GetDirectorDetails;
using Movie_Store_Web_Api.Application.DirectorOperations.Queries.GetDirectors;
using Movie_Store_Web_Api.DBOperations;

namespace Movie_Store_Web_Api.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetDirectorsQuery query = new GetDirectorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
            query.DirectorId = id;
            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorModel model)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = model;
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context, _mapper);
            command.DirectorId = id;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.Validate(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector([FromBody] UpdateDirectorModel model, int id)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context, _mapper);
            command.DirectorId = id;
            command.Model = model;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
