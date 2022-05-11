using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie_Store_Web_Api.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateMovieModel Model;
        public int MovieId;

        public UpdateMovieCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException("movie with this id doesnt exist");

            UpdateMovieDto dto = new UpdateMovieDto();

            dto = _mapper.Map<UpdateMovieDto>(Model);

            var ActorList = GetActorsViaIdList(Model.ActorIds);
            dto.Actors = ActorList;

            movie = _mapper.Map<UpdateMovieDto, Movie>(dto,movie); 
            _context.Movies.Update(movie);
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

    public class UpdateMovieModel
    {
        public UpdateMovieModel()
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

    public class UpdateMovieDto
    {
        public UpdateMovieDto()
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
