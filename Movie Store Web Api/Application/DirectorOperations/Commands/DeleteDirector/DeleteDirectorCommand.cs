using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using System;
using System.Linq;namespace Movie_Store_Web_Api.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public MovieStoreDbContext _context { get; set; }
        public IMapper _mapper { get; set; }
        public int DirectorId { get; set; }
        public DeleteDirectorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(c => c.Id == DirectorId);
            if (director is null)
                throw new InvalidOperationException("there is no director with this id");

            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}
