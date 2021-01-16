using FluentValidation;
using LogChallenge.Domain.Entities;
using System;

namespace LogChallenge.Domain.Validations
{
    public class LogValidator : AbstractValidator<Log>
    {
        public LogValidator()
        {
            RuleFor(x => x.Host)
                .NotNull().NotEmpty().WithMessage("The host field is required.")
                .Length(1, 20).WithMessage("The Host length must be between 1 and 20.");
            RuleFor(x => x.Identity)
                .MaximumLength(50).WithMessage("The Identity maximum characters is 50.");
            RuleFor(x => x.User)
                .MaximumLength(50).WithMessage("The User maximum characters is 50.");
            RuleFor(x => x.DateTime)
                .NotNull().NotEmpty().WithMessage("The DateTime field is required.");
            RuleFor(x => x.Request)
                .NotNull().NotEmpty().WithMessage("The Request field is required.")
                .Length(1, 255).WithMessage("The Request length must be between 1 and 255.");
            RuleFor(x => x.StatusCode)
                .NotNull().NotEmpty().WithMessage("The StatusCode field is required.")
                .InclusiveBetween(100, 999).WithMessage("The StatusCode number must be between 100 and 999.");
            RuleFor(x => x.Size)
                .InclusiveBetween(0, Int32.MaxValue).WithMessage("The Size number must be between 100 and 999.");
            RuleFor(x => x.Referer)
                .MaximumLength(255).WithMessage("The Referer maximum characters is 255.");
            RuleFor(x => x.UserAgent)
                .MaximumLength(255).WithMessage("The Referer maximum characters is 255.");
        }
    }

}




