using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.IntRepository;
using MultiCoreApp.DataAccessLayer;
using MultiCoreApp.DataAccessLayer.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Life-cycle ==> Iliskili kodun yasam suresi
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<MultiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConStr"),sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
        sqlOptions.MigrationsAssembly("MultiCoreApp.DataAccessLayer");
    });
});
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

app.Run();
