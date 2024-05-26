using FluentValidation;
using FluentValidation.Validators;

namespace eCommerceServer.Application.Utilities;

public sealed class TaxNumberMustBeValid<T> : PropertyValidator<T, string>
{
    public override string Name => "TaxNumberMustBeValid";

    public override bool IsValid(ValidationContext<T> context, string value)
    {
        if (value.Length < 10 || value.Length > 11) return false;

        bool isValueValid = false;

        if (value.Length == 10)
        {
            isValueValid = IsValidTaxNumber(value);
        }
        else
        {
            isValueValid = IsValidTcNumber(value);
        }
        return isValueValid;
    }

    private bool IsValidTcNumber(string tc)
    {
        if (tc.Length != 11 || !long.TryParse(tc, out _)) return false;

        int[] digits = new int[11];
        for (int i = 0; i < 11; i++)
        {
            digits[i] = int.Parse(tc[i].ToString());
        }

        int sumOdd = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
        int sumEven = digits[1] + digits[3] + digits[5] + digits[7];

        int digit10 = ((sumOdd * 7) - sumEven) % 10;
        if (digit10 != digits[9]) return false;

        int sumTotal = sumOdd + sumEven + digits[9];
        int digit11 = sumTotal % 10;
        if (digit11 != digits[10]) return false;

        return true;
    }

    private bool IsValidTaxNumber(string taxNumber)
    {
        if (taxNumber.Length != 10 || !long.TryParse(taxNumber, out _)) return false;

        int[] digits = new int[10];
        for (int i = 0; i < 10; i++)
        {
            digits[i] = int.Parse(taxNumber[i].ToString());
        }

        int sum = 0;
        int lastDigit;

        for (int i = 0; i < 9; i++)
        {
            int tmp = (digits[i] + (9 - i)) % 10;
            sum += tmp * (1 << (9 - i));
        }

        lastDigit = sum % 11;
        lastDigit = lastDigit == 10 ? 0 : lastDigit;

        return lastDigit == digits[9];
    }

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return "You need to enter a valid {PropertyName}";
    }
}
