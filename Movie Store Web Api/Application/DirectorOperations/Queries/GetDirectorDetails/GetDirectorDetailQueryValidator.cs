using FluentValidation;
namespace Movie_Store_Web_Api.Application.DirectorOperations.Queries.GetDirectorDetails
{


    public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
        {
            RuleFor(query => query.DirectorId).GreaterThan(0);

        }
    }
}
