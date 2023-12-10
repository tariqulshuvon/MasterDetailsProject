using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PracticalTaskGNIS.Models;

namespace PracticalTaskGNIS.Configurations;

public class CorporateConfiguration : IEntityTypeConfiguration<CorporateCustomer>
{
    public void Configure(EntityTypeBuilder<CorporateCustomer> builder)
    {
        builder.ToTable(nameof(CorporateCustomer));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CustomerName).HasMaxLength(100).IsRequired(true);
    }
}

