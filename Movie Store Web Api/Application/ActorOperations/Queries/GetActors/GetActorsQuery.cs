using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System.Collections.Generic;
using System.Linq;
namespace Movie_Store_Web_Api.Application.ActorOperations.Queries.GetDirectors
{
    public class GetActorsQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        

        public GetActorsQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Actor> Handle()
        {
            var movies = _context.Actors.Include(m => m.Movies).ToList();
            return movies;

        }
    }
}
