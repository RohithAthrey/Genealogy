using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Data.Models;

namespace webapi;
public static class LoginEndpoints
{
    public static void MapLoginEndpoints(this WebApplication app)
    {
        app.MapPost("/login", async (LoginDTO loginDTO, AppDbContext dbContext) =>
        {
            var user = await dbContext.Person.FirstOrDefaultAsync(p =>
          p.LoginId == loginDTO.Username && p.Password == loginDTO.Password);
            if (user != null)
            {
                return Results.Ok(user.PersonID);
            }
            else
            {
                // 500 = internal server error.
                return Results.StatusCode(500);
            }
        });
    }
    
}
