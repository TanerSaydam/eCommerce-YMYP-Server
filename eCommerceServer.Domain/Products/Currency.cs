namespace eCommerceServer.Domain.Products;
public sealed class Currency
{
    public Currency BTC = new("BTC");
    public Currency ETH = new("ETH");

    public Currency(string v)
    {
    }
}