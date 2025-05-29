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

builder.Services.AddScoped<IHouseRepository, HouseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


/* The following code sets up a simple GET endpoint that retrieves all houses from the database. And we do so by using the HouseDBContext to access the DbSet<Houses> property, which represents the collection of HouseEntity objects in the database. 
But we'll return the data through a DTO, which we'll create on the fly using LINQ's Select method to project the HouseEntity objects into a simpler form. */
// app.MapGet("/houses", (HouseDBContext db) => db.Houses
//     .Select(h => new HouseDTO(h.ID, h.Address, h.Country, h.Price)).ToListAsync());

app.MapGet("/houses", (IHouseRepository repository) => repository.GetAll());

app.Run();

