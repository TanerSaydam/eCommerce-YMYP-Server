using eCommerceServer.Domain.Abstractions;

namespace eCommerceServer.Domain.Products;
public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
 
}
