using FluentValidation;

namespace ERPServer.Application.Features.Customers.UpdateCustomer
{
    public sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {

        public UpdateCustomerCommandValidator()
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
