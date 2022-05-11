using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using System;
using System.Linq;

namespace Movie_Store_Web_Api.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int MovieId;

        public DeleteMovieCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == MovieId);
            if (movie == null)
                throw new InvalidOperationException("there is no movie with this id");
            movie.IsActive = false;
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }
    }
}
