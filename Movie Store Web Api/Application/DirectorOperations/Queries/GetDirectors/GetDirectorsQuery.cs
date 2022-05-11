using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System.Collections.Generic;
using System.Linq;
namespace Movie_Store_Web_Api.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Director> Handle()
        {
            var directors = _context.Directors.Include(m => m.DirectedMovies).ToList();
            return directors;

        }
    }
}
