using FluentValidation;

namespace Movie_Store_Web_Api.Application.ActorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
        {
            RuleFor(query => query.ActorId).GreaterThan(0);

        }
    }
}
