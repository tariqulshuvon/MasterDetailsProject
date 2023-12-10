using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PracticalTaskGNIS.Models;

namespace PracticalTaskGNIS.Configurations;

public class CorporateOrIndividualConfiguration : IEntityTypeConfiguration<CorporateOrIndividual>
{
    public void Configure(EntityTypeBuilder<CorporateOrIndividual> builder)
    {
        builder.ToTable(nameof(CorporateOrIndividual));
        builder.HasKey(x => x.Id);
    }
}