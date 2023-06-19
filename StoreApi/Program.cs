global using StoreCommon.Models;
global using Microsoft.EntityFrameworkCore;

using StoreApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
);

builder.Services.AddControllers();








var app = builder.Build();

await using(var scope = app.Services.CreateAsyncScope()) {
    using var context = scope.ServiceProvider.GetService<MyContext>();
    await context.Database.MigrateAsync();
    //await context.Database.EnsureCreatedAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 