using cw10.RequestModels;
using FluentValidation;

namespace cw10.Validators;

public class AddProductValidator : AbstractValidator<AddProductRequestModel>
{
    public AddProductValidator()
    {
        RuleFor(e => e.productName).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(e => e.productWeight).NotEmpty().NotNull();
        RuleFor(e => e.productWidth).NotEmpty().NotNull();
        RuleFor(e => e.productHeight).NotEmpty().NotNull();
        RuleFor(e => e.productDepth).NotEmpty().NotNull();
    }
}