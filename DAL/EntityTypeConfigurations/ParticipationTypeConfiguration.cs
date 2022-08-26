using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfigurations;

public class ParticipationTypeConfiguration : IEntityTypeConfiguration<Participation>
{
    public void Configure(EntityTypeBuilder<Participation> builder)
    {
        builder.ToTable("Participations").HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.RoomId).IsRequired();
        builder.HasOne(x => x.User).WithMany(u => u.Participations)
            .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Room).WithMany(u => u.Participations)
            .HasForeignKey(x => x.RoomId).OnDelete(DeleteBehavior.Cascade);
    }
}
