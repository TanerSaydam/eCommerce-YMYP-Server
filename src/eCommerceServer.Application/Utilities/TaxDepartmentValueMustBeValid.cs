using eCommerceServer.Domain.Companies;
using FluentValidation;
using FluentValidation.Validators;

namespace eCommerceServer.Application.Utilities;

public class TaxDepartmentValueMustBeValid<T> : PropertyValidator<T, int>
{
    public override string Name => "TaxDepartmentValueMustBeValid";

    public TaxDepartmentValueMustBeValid()
    {
    }

    public override bool IsValid(ValidationContext<T> context, int value)
    {
        // Check if the value exists in the SmartEnum
        var valid = TaxDepartmentSmartEnum.List.Any(taxDepartment => taxDepartment.Value == value);
        return valid;
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return "{PropertyName} must be a valid tax department value.";
    }
}