using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Movie_Store_Web_Api.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public MovieStoreDbContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public CreateActorModel Model { get; set; }

        public CreateActorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(c => c.FirstName.ToLower() == Model.FirstName.ToLower() && c.LastName.ToLower() == Model.LastName.ToLower());
            if (actor is not null)
                throw new InvalidOperationException("a actor with  this name & surname already exist");
            actor = _mapper.Map<Actor>(Model);
            actor.Movies = GetActorMoviesViaIdList(Model.MovieIds);
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        private List<Movie> GetActorMoviesViaIdList(List<int> ids)
        {
            var MovieList = new List<Movie>();
            foreach (int item in ids)
            {
                Movie movie = _context.Movies.SingleOrDefault(a => a.Id == item);
                if (movie is null)
                    throw new InvalidOperationException($"movie with this id: {item} is not exist");
                MovieList.Add(movie);
            }

            return MovieList;
        }
    }

    public class CreateActorModel
    {
        public CreateActorModel()
        {
            MovieIds = new List<int>();
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<int> MovieIds { get; set; }
    }
}
