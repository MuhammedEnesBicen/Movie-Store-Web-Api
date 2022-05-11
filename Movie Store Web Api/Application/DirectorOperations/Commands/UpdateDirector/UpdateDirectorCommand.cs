using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace Movie_Store_Web_Api.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDirectorModel Model;
        public int DirectorId;

        public UpdateDirectorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(m => m.Id == DirectorId);
            director = _mapper.Map<Director>(Model);
            director.DirectedMovies = GetDirectedMoviesViaIdList(Model.DirectedMovieIds);
            _context.Directors.Update(director);
            _context.SaveChanges();
        }

        private List<Movie> GetDirectedMoviesViaIdList(List<int> ids)
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
    public class UpdateDirectorModel
    {
        public UpdateDirectorModel()
        {
            DirectedMovieIds = new List<int>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<int> DirectedMovieIds { get; set; }
    }
}
