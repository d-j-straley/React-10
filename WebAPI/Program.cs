using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

/*
Note that the following code, which sets up the SQLite database context, is commented out in the original code, which was originally using a different method of configuring the database context, and was in the file HouseDBContext.cs.
*/
builder.Services.AddDbContext<HouseDBContext>(options =>
    options.UseSqlite($"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HouseDB.db")}")
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapGet("/houses", (HouseDBContext db) => db.Houses);


app.Run();

