using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Movie_Store_Web_Api.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public MovieStoreDbContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public CreateDirectorModel Model { get; set; }

        public CreateDirectorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(c => c.FirstName.ToLower() == Model.FirstName.ToLower() && c.LastName.ToLower() == Model.LastName.ToLower());
            if (director is not null)
                throw new InvalidOperationException("a director with  this name & surname already exist");
            director = _mapper.Map<Director>(Model);
            director.DirectedMovies = GetDirectedMoviesViaIdList(Model.MovieIds);
            _context.Directors.Add(director);
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

    public class CreateDirectorModel
    {
        public CreateDirectorModel()
        {
            MovieIds = new List<int>();
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<int> MovieIds { get; set; }
    }
}
