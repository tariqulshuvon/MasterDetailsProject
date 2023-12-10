using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PracticalTaskGNIS.Models;

namespace PracticalTaskGNIS.Configurations;

public class IndividualConfiguration : IEntityTypeConfiguration<IndividualCustomer>
{
    public void Configure(EntityTypeBuilder<IndividualCustomer> builder)
    {
        builder.ToTable(nameof(IndividualCustomer));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CustomerName).HasMaxLength(100).IsRequired(true);
    }
}

