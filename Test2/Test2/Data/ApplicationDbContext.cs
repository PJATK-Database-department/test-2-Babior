using Microsoft.EntityFrameworkCore;
using Test2.Configurations;
using Test2.Entities;

namespace Test2.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
        
    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBulider)
    {
        base.OnConfiguring(optionsBulider);
        optionsBulider.UseSqlServer(
            "Server=db-mssql16.pjwstk.edu.pl;Initial Catalog=s22355;Integrated Security=true;TrustServerCertificate=true");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ClientConfig());
        modelBuilder.ApplyConfiguration(new EmployeeConfig());
        modelBuilder.ApplyConfiguration(new ClientOrderConfig());
        modelBuilder.ApplyConfiguration(new ConfectioneryConfig());
        modelBuilder.ApplyConfiguration(new ConfectioneryClientOrderConfig());
    }
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<ClientOrder> ClientOrders { get; set; }
    public DbSet<Confectionery> Confectioneries { get; set; }
    public DbSet<ConfectioneryClientOrder> ConfectioneryClientOrders { get; set; }
}