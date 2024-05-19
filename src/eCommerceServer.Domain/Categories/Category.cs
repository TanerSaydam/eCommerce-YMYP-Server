using eCommerceServer.Domain.Abstractions;

namespace eCommerceServer.Domain.Categories;
public sealed class Category : Entity
{
    public Name Name { get; set; } = new(string.Empty);
    public Guid? MainCategoryID { get; set; }
    public Category? MainCategory { get; set; }
}

