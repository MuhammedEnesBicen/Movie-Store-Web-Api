using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using System;
using System.Linq;
namespace Movie_Store_Web_Api.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public MovieStoreDbContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public int ActorId { get; set; }
        public DeleteActorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(c => c.Id == ActorId);
            if (actor is null)
                throw new InvalidOperationException("there is no actor with this id");

            var movies = _context.Movies.Where(x=> x.Actors.Where(a => a.Id==ActorId).Count()>0).ToList();
            if(movies.Count()>0)
                throw new InvalidOperationException("You cannot delete this actor because there are movie entries which has this actor infos.");


            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
    }
}
