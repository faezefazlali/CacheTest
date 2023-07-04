using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using CacheTest.Services.AutoMapperConfig;
using CacheTest.Core.Module;
using CacheTest.Domain;
using Microsoft.EntityFrameworkCore;
using CacheTest.Services.Contracts.Common;
using CacheTest.Core.DataAccess;
using CacheTest.Services.Modules.Common;
using CacheTest.Services.Contracts.Cache;
using CacheTest.Services.Modules.Cache;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = $"{MyConfig.GetValue<string>("Redis:Connection")}";
});


services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            /*.AllowCredentials()*/);
});




services.AddAutoMapper(typeof(MapperConfig).Assembly);


var conStr = MyConfig.GetConnectionString("dbconn");
services.AddDbContext<DB>(options => options

.UseSqlServer(conStr));
services.AddScoped<DbContext, DB>();

Extensions.Mapper = services.BuildServiceProvider().GetService<IMapper>();
Extensions.ConnStr = conStr;

var key = Encoding.ASCII.GetBytes(MyConfig.GetSection("AppSettings:Secret").Value);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



services.AddHttpContextAccessor();
services.AddSingleton<IRedisService, RedisService>();
services.AddSingleton<IMemoryCacheService, MemoryCacheService>();

services.AddScoped<ICacheService, CacheService>();

services.AddScoped<CurrentUser>();
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IBookService, BookService>();



var app = builder.Build();

//{
//    using var scope = app.Services.CreateScope();
//    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
//    await context.Init();
//}

//builder.Services.AddRedisCache(options =>
//{
//    options.Configuration = builder.Configuration["RedisCache:Connection"];
//    options.InstanceName = builder.Configuration["RedisCache:InstanceName"];
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();






app.UseStaticFiles();

app.UseCors("CorsPolicy");

//app.UseMiddleware(typeof(SecureDownloadUrlsMiddleware));

app.UseRouting();
app.UseAuthentication();
