namespace eCommerceServer.Domain.Companies;

public sealed record TaxNumber
{
    public TaxNumber(string value)
    {
        if (value.Length < 10 || value.Length > 11)
        {
            throw new ArgumentException("Vergi Numarası geçerli degil!");
        }

        Value = value;
        
    }
    public string Value { get; init; }
}