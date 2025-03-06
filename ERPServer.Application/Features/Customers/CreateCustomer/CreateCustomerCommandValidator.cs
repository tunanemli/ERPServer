using FluentValidation;

namespace ERPServer.Application.Features.Customers.CreateCustomer
{
    public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand> {
    
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.TaxDepartment).NotEmpty();
            RuleFor(c => c.TaxNumber).MinimumLength(11);
            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.Town).NotEmpty();
            RuleFor(c => c.FullAddress).NotEmpty();
        }
    
    }
}
