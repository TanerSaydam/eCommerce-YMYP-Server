using eCommerceServer.Domain.Abstractions;

namespace eCommerceServer.Domain.Companies;
public sealed class Company : Entity
{
    public Name Name { get; set; } = default!;
    public TaxDepartmentSmartEnum TaxDepartment { get; set; } = TaxDepartmentSmartEnum.Esenyurt;
    public TaxNumber TaxNumber { get; set; } = default!;
    public Address Address { get; set; } = default!;
}
