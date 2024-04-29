using FluentValidation;
using WebApplication1.DTOs;

namespace WebApplication1.Validators;

public class WarehouseProductValidator : AbstractValidator<WarehouseProductDTO>
{
    public WarehouseProductValidator()
    {
        RuleFor(e => e.IdProduct).NotNull().NotEmpty();
        RuleFor(e => e.IdWarehouse).NotNull().NotEmpty();
        RuleFor(e => e.Amount).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(e => e.CreatedAt).NotNull().NotEmpty().LessThanOrEqualTo(DateTime.Now);
    }
}