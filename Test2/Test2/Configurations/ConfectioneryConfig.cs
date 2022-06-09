using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test2.Entities;

namespace Test2.Configurations;

public class ConfectioneryConfig : IEntityTypeConfiguration<Confectionery>
{
    public void Configure(EntityTypeBuilder<Confectionery> builder)
    {
        builder.HasData(
            new Confectionery{IdConfectionery = 1, Name = "Twix", PricePerOne = 4},
            new Confectionery {IdConfectionery = 2, Name = "Snickers", PricePerOne = 5},
            new Confectionery {IdConfectionery = 3, Name = "Mars", PricePerOne = 4}
        );
    }
}