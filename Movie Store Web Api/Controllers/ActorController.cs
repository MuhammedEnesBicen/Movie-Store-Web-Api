using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.CreateActor;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.DeleteActor;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.UpdateActor;
using Movie_Store_Web_Api.Application.ActorOperations.Queries.GetDirectorDetail;
using Movie_Store_Web_Api.Application.ActorOperations.Queries.GetDirectors;
using Movie_Store_Web_Api.DBOperations;

namespace Movie_Store_Web_Api.Controllers
{
    [Route("[controller]s")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetActorsQuery query = new GetActorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper); 
            query.ActorId=id;
            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            query.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorModel model)
        {
            CreateActorCommand command = new CreateActorCommand(_context,_mapper);  
            command.Model = model;
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        } 

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context,_mapper);
            command.ActorId = id;
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.Validate(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor([FromBody]UpdateActorModel model ,int id)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context,_mapper);
            command.ActorId=id;
            command.Model = model;
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
