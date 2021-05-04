using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public Context() {}
    public DbSet<Produto> Produtos { get; set; }

    public Context(DbContextOptions options) : base(options) {}
}
