using IoTUserService.Application.Interfaces.Security;
using IoTUserService.Domain.Repositories;
using IoTUserService.Infrastructure.Persistence.Context;
using IoTUserService.Infrastructure.Repositories;
using IoTUserService.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
 

builder.Services.AddControllers();


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(typeof(Program).Assembly);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
