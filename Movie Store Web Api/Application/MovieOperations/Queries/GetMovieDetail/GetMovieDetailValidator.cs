using FluentValidation;

namespace Movie_Store_Web_Api.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailValidator()
        {
            RuleFor(query => query.MovieId).GreaterThan(0);
        }
    }
}
