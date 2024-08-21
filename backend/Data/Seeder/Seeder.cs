using Data.Context;
using Domain.Commands.AddUser;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Seeder;

public static class Seeder
{
    public async static Task CreateAdminUser(ProjectContext? context) {
        if(context == null) return;

        if (await context.Users.AnyAsync(p => p.Name == "admin"))
            return;

        var passwordHasher = new PasswordHasher<object?>();
        var password = passwordHasher.HashPassword(null, "1234");
        
        var user = new User("admin@gmail.com", "admin",password);

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }
}
