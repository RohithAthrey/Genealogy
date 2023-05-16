using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:4200", "https://localhost:4200", "https://calm-water-04859b403.azurestaticapps.net");
        });
});
// builder.Services.AddControllers();

//Add database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<AppDbContext>(dbContextOptionsBuilder =>
//    dbContextOptionsBuilder.UseSqlite(builder.Configuration["ConnectionStrings:DefaultConnection"]));


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
// app.UseAuthorization();

app.UseCors("CORSPolicy");

app.MapRegistrationEndpoints();


// app.MapControllers();

app.Run();
