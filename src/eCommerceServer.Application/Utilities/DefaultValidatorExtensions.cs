using FluentValidation;

namespace eCommerceServer.Application.Utilities;
public static partial class DefaultValidatorExtensions
{
    public static IRuleBuilderOptions<T, int> TaxDepartmentValueMustBeValid<T>(this IRuleBuilder<T, int> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new TaxDepartmentValueMustBeValid<T>());
    }

    public static IRuleBuilderOptions<T, string> TaxNumberMustBeValid<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new TaxNumberMustBeValid<T>());
    }
}