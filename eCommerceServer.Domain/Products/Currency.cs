namespace eCommerceServer.Domain.Products;
public sealed class Currency
{
    public static readonly Currency BTC = new("BTC");
    public static readonly Currency ETH = new("ETH");

    public Currency(string v)
    {
    }
}