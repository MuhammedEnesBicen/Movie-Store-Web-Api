using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Movie_Store_Web_Api.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Movie> Handle()
        {
            var movies = _context.Movies.Include(m=> m.Actors).Include(m=> m.Genre).ToList();
            return movies;

        }
    }
}
