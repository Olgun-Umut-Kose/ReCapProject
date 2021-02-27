using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(3);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();
        }
    }
}