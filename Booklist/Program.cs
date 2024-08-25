using LibraryService;
using LibraryService.RepositoryClass;
using LibraryService.Repositorys;
using LibraryService.Service;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
{

    options.UseSqlServer("Server=DESKTOP-OD0I8PV\\SQLEXPRESS;Database=test;Trusted_Connection=True; user=sa;password=12345678; TrustServerCertificate = True;");

    options.EnableSensitiveDataLogging();

});



builder.Services.AddScoped<IBookListRepository, BookListRepository>();
builder.Services.AddScoped<IAuthorListRepository, AuthorRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();




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
