using FluentValidation;

namespace ERPServer.Application.Features.Products.CreateProduct
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.TypeValue).NotEmpty().GreaterThan(0);
        }
    }
}
