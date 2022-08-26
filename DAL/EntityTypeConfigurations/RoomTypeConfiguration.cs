using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfigurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms").HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Type).IsRequired();
        builder.HasMany(x => x.Messages).WithOne(m => m.Room).HasForeignKey(x => x.RoomId);
        builder.HasMany(x => x.Participations).WithOne(m => m.Room).HasForeignKey(x => x.RoomId);
    }
}