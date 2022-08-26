using DAL.EntityTypeConfigurations;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DAL;

public class DataContext : DbContext
{
    public DataContext()
    {
        
    }
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlite(@"Data Source=D:\Visual Studio Projects\Reenbit\WebChat\API\chatapp.db");
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Participation> Participations { get; set; }
    // public DbSet<RoomUser> RoomUser { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserTypeConfiguration());
        builder.ApplyConfiguration(new RoomTypeConfiguration());
        builder.ApplyConfiguration(new MessageTypeConfiguration());
        builder.ApplyConfiguration(new ParticipationTypeConfiguration());
    } 
}