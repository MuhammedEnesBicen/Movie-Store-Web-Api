using AutoMapper;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.CreateActor;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.UpdateActor;
using Movie_Store_Web_Api.Application.CustomerOperations.Commands.CreateCustomer;
using Movie_Store_Web_Api.Application.DirectorOperations.Commands.CreateDirector;
using Movie_Store_Web_Api.Application.DirectorOperations.Commands.UpdateDirector;
using Movie_Store_Web_Api.Application.MovieOperations.Commands.CreateMovie;
using Movie_Store_Web_Api.Application.MovieOperations.Commands.UpdateMovie;
using Movie_Store_Web_Api.Application.OrderOperations.Commands.CreateOrder;
using Movie_Store_Web_Api.Entities;

namespace Movie_Store_Web_Api.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Source,Target>
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<UpdateMovieModel,UpdateMovieDto>();
            CreateMap<CreateMovieModel, CreateMovieDto>();
            CreateMap<CreateMovieDto,Movie>();
            CreateMap<CreateCustomerModel, Customer>();


            CreateMap<CreateDirectorModel, Director>();
            CreateMap<UpdateDirectorModel, Director>();

            CreateMap<CreateActorModel, Actor>();
            CreateMap<UpdateActorModel, Actor>();

            CreateMap<CreateOrderModel, Order>();

        }
    }
}
