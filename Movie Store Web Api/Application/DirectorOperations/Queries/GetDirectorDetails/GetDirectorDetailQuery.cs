using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System.Linq;
namespace Movie_Store_Web_Api.Application.DirectorOperations.Queries.GetDirectorDetails
{
    public class GetDirectorDetailQuery
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int DirectorId;

        public GetDirectorDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Director Handle()
        {
            return _context.Directors.SingleOrDefault(a => a.Id == DirectorId);
        }
    }
}
