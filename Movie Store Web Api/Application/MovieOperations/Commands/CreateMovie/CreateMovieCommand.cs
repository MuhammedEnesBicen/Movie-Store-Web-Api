using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie_Store_Web_Api.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateMovieModel Model;

        public CreateMovieCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Name == Model.Name);
            if (movie is not null)
                throw new InvalidOperationException("A movie with this name already exists");

            CreateMovieDto dto = new CreateMovieDto();
            
            dto = _mapper.Map<CreateMovieDto>(Model);
            //dto.Actors = _mapper.Map<List<Actor>>(Model.ActorIds);
            /*
             We are getting Actor objects(directly from db) with ActorIds.
             */
            var ActorList = GetActorsViaIdList(Model.ActorIds);
            dto.Actors = ActorList;
            movie = _mapper.Map<Movie>(dto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        private List<Actor> GetActorsViaIdList(List<int> ids)
        {
            var ActorList = new List<Actor>();
            foreach (int item in ids)
            {
                Actor actor = _context.Actors.SingleOrDefault(a => a.Id == item);
                if (actor is null)
                    throw new InvalidOperationException($"Actor with this id: {item} is not exist");
                ActorList.Add(actor);
            }

            return ActorList;
        }
    }

  

    public class CreateMovieModel
    {
        public CreateMovieModel()
        {
            ActorIds = new List<int>();
        }

        
        
        public string Name { get; set; }
        public DateTime MovieYear { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public List<int> ActorIds { get; set; }
        public Double Price { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class CreateMovieDto
    {
        public CreateMovieDto()
        {
            Actors = new List<Actor>();
        }



        public string Name { get; set; }
        public DateTime MovieYear { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public List<Actor> Actors { get; set; }
        public Double Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
