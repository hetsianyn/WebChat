using System.Text.Json;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Extensions;

public class Seed
{
    public static async Task SeedData(DataContext context)
    {
        if (await context.Users.AnyAsync()) return;

        var usersData = await File.ReadAllTextAsync(@"D:\Visual Studio Projects\Reenbit\WebChat\DAL\Extensions\UsersSeed.json");
        var users = JsonSerializer.Deserialize<List<User>>(usersData);

        foreach (var user in users)
        {
            context.Users.Add(user);
        }
        
        if (await context.Rooms.AnyAsync()) return;

        var roomsData = await File.ReadAllTextAsync(@"D:\Visual Studio Projects\Reenbit\WebChat\DAL\Extensions\RoomsSeed.json");
        var rooms = JsonSerializer.Deserialize<List<Room>>(roomsData);

        foreach (var room in rooms)
        {
            context.Rooms.Add(room);
        }

        await context.SaveChangesAsync();
    }
}