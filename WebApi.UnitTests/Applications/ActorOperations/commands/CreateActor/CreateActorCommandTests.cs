using AutoMapper;
using FluentAssertions;
using Movie_Store_Web_Api.Application.ActorOperations.Commands.CreateActor;
using Movie_Store_Web_Api.DBOperations;
using System;
using System.Collections.Generic;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.ActorOperations.commands.CreateActor
{
    public class CreateActorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void CreateActorCommand_ShouldReturnError_WhenActorAlreadyExist()
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = new CreateActorModel() { FirstName = "actor a", LastName = "a last" };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("a actor with  this name & surname already exist");
        }

        [Fact]
        public void CreateActorCommand_ShouldReturnError_WhenActorsMovieListContainNonExistMovieId()
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = new CreateActorModel() { FirstName = "actor z", LastName = "z last" ,MovieIds=new List<int> { 12 } };

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("movie with this id: 12 is not exist");
        }
    }
}
