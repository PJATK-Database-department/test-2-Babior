using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Entities;

namespace Test2.Configurations;

public class ClientConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasData(
            new Client {IdClient = 1, FirstName = "Karyna", LastName = "Bartashevich"},
            new Client {IdClient = 2, FirstName = "Nastya", LastName = "Babior"},
            new Client {IdClient = 3, FirstName = "Hanna", LastName = "Tamkovich"}
        );
    }
}