using FluentValidation;

namespace ERPServer.Application.Features.Depots.UpdateDepot
{
    public sealed class UpdateDepotCommandValidator : AbstractValidator<UpdateDepotCommand>
    {
        public UpdateDepotCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Town).NotEmpty();
            RuleFor(c => c.FullAddress).NotEmpty();
            RuleFor(c => c.City).NotEmpty();
        }
    }
}
