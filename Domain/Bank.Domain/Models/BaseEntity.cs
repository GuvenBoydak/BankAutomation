namespace Bank.Domain.Models;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.Now;
        IsDeleted = false;
    }

    public Guid Id { get; }
    public DateTime CreatedDate { get; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}