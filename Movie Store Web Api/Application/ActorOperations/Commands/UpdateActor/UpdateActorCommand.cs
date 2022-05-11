using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Movie_Store_Web_Api.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateActorModel Model;
        public int ActorId;

        public UpdateActorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(m => m.Id == ActorId);
            if (actor is null)
                throw new InvalidOperationException("Actor with this id doesnt exist");
            actor = _mapper.Map<Actor>(Model);
            _context.Actors.Update(actor);
            _context.SaveChanges();
        }
    }
    public class UpdateActorModel
    {
        public UpdateActorModel()
        {
            MovieIds = new List<int>();
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<int> MovieIds { get; set; }
    }
}
