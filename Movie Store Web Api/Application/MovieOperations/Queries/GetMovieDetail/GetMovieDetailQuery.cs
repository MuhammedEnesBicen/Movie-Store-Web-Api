using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System.Linq;

namespace Movie_Store_Web_Api.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int MovieId;

        public GetMovieDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Movie Handle()
        {
            return _context.Movies.SingleOrDefault(m => m.Id == MovieId);
        }
    }
}
