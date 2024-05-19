namespace eCommerceServer.Domain.Categories;

public sealed record Name
{
    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("İsim alanı boş olamaz.");
        }

        if (value.Length < 3)
        {
            throw new ArgumentException("İsim alanı en az 3 karakter olmalıdır.");
        }

        Value = value;
    }
    public string Value { get; init; }
}

