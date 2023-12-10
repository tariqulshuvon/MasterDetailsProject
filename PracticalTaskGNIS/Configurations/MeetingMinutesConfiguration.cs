using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PracticalTaskGNIS.Models;

namespace PracticalTaskGNIS.Configurations;

public class MeetingMinutesConfiguration : IEntityTypeConfiguration<MeetingMinutes>
{
    public void Configure(EntityTypeBuilder<MeetingMinutes> builder)
    {
        builder.ToTable(nameof(MeetingMinutes));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.MeetingPlace).HasMaxLength(100).IsRequired(true);
    }
}