using FluentValidation;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validator
{
    public class AddRegionValidator : AbstractValidator<AddRegionDTO>
    {
        public AddRegionValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Lat).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Long).GreaterThanOrEqualTo(0);
        }
    }
}
