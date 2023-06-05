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
          p.LoginId == loginDTO.Username && p.Password == loginDTO.Password && p.IsActive==true);
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
        app.MapGet("/login/getUserRoleModules/{Id}", async (int Id, AppDbContext dbContext) =>
        {
            var query = await (from p in dbContext.Person
                         join pr in dbContext.PersonRole
                         on p.PersonID equals pr.PersonID
                         join r in dbContext.Role
                         on pr.RoleID equals r.RoleID
                         where p.PersonID == Id
                         select new UserRoleDTO
                         {
                             FullName = p.FirstName + p.LastName,
                             RoleName = r.RoleName,
                             RoleId=r.RoleID,
                             PersonId=p.PersonID,
                             PersonRoleId=pr.PersonRoleID

                         }).FirstOrDefaultAsync();
            if (query != null)
            {
                return Results.Ok(query);
            }
            else
            {
                return Results.NotFound();
            }
        });
    }
    
}
