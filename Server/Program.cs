using Microsoft.EntityFrameworkCore;
using Server.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString(name: "DefaultConnection"
        ));
});

builder.Services.AddRouting(configureOptions: options => options.LowercaseUrls = true);
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsPolicy",
//        builder =>
//        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
//        );
//});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction: c =>
{
    c.SwaggerDoc(name: "v1", info: new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Server", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "PortfolioServer API");
    swaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseStaticFiles();
// app.UseCors("CorsPolicy");app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
