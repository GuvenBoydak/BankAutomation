namespace Bank.Domain.Models;

public class Role : BaseEntity
{
    public string Name { get; set; }

    //Relational property
    public List<User> Users { get; set; }
}