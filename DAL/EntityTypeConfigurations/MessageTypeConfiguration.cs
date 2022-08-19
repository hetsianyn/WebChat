using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfigurations;

public class MessageTypeConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages").HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.RoomId).IsRequired();
        builder.HasOne(m => m.User).WithMany(u => u.Messages).HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(m => m.Room).WithMany(r => r.Messages).HasForeignKey(m => m.RoomId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}