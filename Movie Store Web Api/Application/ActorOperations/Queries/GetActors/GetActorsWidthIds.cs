using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie_Store_Web_Api.DBOperations;
using Movie_Store_Web_Api.Entities;
using System.Collections.Generic;
using System.Linq;
namespace Movie_Store_Web_Api.Application.ActorOperations.Queries.GetActors
{
    /*
     The purpose of this class is to getting Actor objects according to id property.
     This is necessary when creating movie objects.
     Movie objects have List <Actor> property..
     */
    public class GetActorsWidthIds
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorsWidthIds(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public List<Actor> GetActors(List<int> ids)
        //{
        //    var actors = new List<Actor>();
        //    foreach (var id in ids)
        //    {
        //        GetActorDetailQuery
        //    }
        //}
    }
}
