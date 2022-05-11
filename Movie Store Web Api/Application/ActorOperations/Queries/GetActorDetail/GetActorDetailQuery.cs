using AutoMapper;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System;
using System.Linq;
namespace Movie_Store_Web_Api.Application.ActorOperations.Queries.GetDirectorDetail
{
    public class GetActorDetailQuery
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int ActorId;

        public GetActorDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Actor Handle()
        {
            var actor =  _context.Actors.SingleOrDefault(a => a.Id == ActorId);
            if (actor is null)
                throw new InvalidOperationException("Actor with this id doesnt exist");
            return actor;
        }
    }
}
