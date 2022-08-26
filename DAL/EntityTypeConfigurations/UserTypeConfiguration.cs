using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityTypeConfigurations;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.HasMany(x => x.Messages).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasMany(x => x.Participations).WithOne(m => m.User).HasForeignKey(x => x.UserId);
    }
}