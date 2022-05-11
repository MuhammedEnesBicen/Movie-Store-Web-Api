using AutoMapper;
using FluentAssertions;
using Movie_Store_Web_Api.Application.ActorOperations.Queries.GetDirectorDetail;
using Movie_Store_Web_Api.DBOperations;
using System;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.ActorOperations.queries
{
    public class GetActorQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void GetActorDetailQuery_ShouldReturnError_WhenActorAlreadyExist()
        {
            GetActorDetailQuery command = new GetActorDetailQuery(_context, _mapper);
            command.ActorId = 23;

            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Actor with this id doesnt exist");
        }
    }
}
