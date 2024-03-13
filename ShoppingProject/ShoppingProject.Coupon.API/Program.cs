using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ShoppingProject.Coupon.API.Interfaces;
using ShoppingProject.Coupon.API.Services;
using ShoppingProject.Coupon.Database.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#if !DEBUG

ApplyMigrations<CouponDbContext>(app);

#endif

app.Run();

#if !DEBUG

void ApplyMigrations<T>(WebApplication? app) where T : DbContext
{
    using (var scope = app!.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<T>();

        if (db.Database.GetPendingMigrations().Any())
        {
            db.Database.Migrate();
        }
    }
}

#endif

void ConfigureServices(IServiceCollection services)
{
    // add services and stuff
    builder.Services.AddDbContext<CouponDbContext>(option =>
    {
        option.UseSqlServer(builder.Configuration.GetConnectionString("CouponDbContextSql"));
    });

    builder.Services.TryAddScoped<ICouponService, CouponService>();
}