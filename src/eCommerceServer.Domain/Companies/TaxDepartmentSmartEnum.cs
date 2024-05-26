using Ardalis.SmartEnum;

namespace eCommerceServer.Domain.Companies;

public sealed class TaxDepartmentSmartEnum : SmartEnum<TaxDepartmentSmartEnum>
{
    public static readonly TaxDepartmentSmartEnum Esenler = new TaxDepartmentSmartEnum("Esenler", 1);
    public static readonly TaxDepartmentSmartEnum Esenyurt = new TaxDepartmentSmartEnum("Esenyurt", 2);
    public static readonly TaxDepartmentSmartEnum Fatih = new TaxDepartmentSmartEnum("Fatih", 3);
    public TaxDepartmentSmartEnum(string name, int value) : base(name, value)
    {
    }
}
