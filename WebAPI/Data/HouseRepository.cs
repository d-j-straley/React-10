using Microsoft.EntityFrameworkCore;

public interface IHouseRepository
{
    Task<List<HouseDTO>> GetAll();
}
public class HouseRepository : IHouseRepository
{
    private readonly HouseDBContext _context;

    public HouseRepository(HouseDBContext context)
    {
        _context = context;
    }
    public async Task<List<HouseDTO>> GetAll()
    {
        return await _context.Houses
            .Select(h => new HouseDTO(h.ID, h.Address, h.Country, h.Price))
            .ToListAsync();
    }
}




/* The following code sets up a simple GET endpoint that retrieves all houses from the database. And we do so by using the HouseDBContext to access the DbSet<Houses> property, which represents the collection of HouseEntity objects in the database. 
But we'll return the data through a DTO, which we'll create on the fly using LINQ's Select method to project the HouseEntity objects into a simpler form. */
// app.MapGet("/houses", (HouseDBContext db) => db.Houses
//     .Select(h => new HouseDTO(h.ID, h.Address, h.Country, h.Price)).ToListAsync());