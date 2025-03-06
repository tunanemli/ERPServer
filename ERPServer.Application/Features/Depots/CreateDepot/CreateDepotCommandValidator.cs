using FluentValidation;

namespace ERPServer.Application.Features.Depots.CreateDepot
{
    public sealed class CreateDepotCommandValidator : AbstractValidator<CreateDepotCommand>
    {
        public CreateDepotCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.Town).NotEmpty();
            RuleFor(c => c.FullAddress).NotEmpty();
        }
    }
}
