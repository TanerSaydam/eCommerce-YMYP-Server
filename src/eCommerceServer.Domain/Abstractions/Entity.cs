namespace eCommerceServer.Domain.Abstractions;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; } = false;

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj is not Entity entity) return false;

        return Id == entity.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
