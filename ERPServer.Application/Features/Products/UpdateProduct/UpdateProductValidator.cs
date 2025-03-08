using FluentValidation;

namespace ERPServer.Application.Features.Products.UpdateProduct
{
    public sealed class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator() 
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.TypeValue).NotEmpty().GreaterThan(0);
        }
    }
}

