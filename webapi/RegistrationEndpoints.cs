using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using webapi.Data;
using webapi.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace webapi;

public static class RegistrationEndpoints
{
    public static void MapRegistrationEndpoints(this WebApplication app)
    {
        app.MapGet("/register", async (AppDbContext dbContext) =>
        {
            List<Gender> allGenders = await dbContext.Gender.ToListAsync();
            return Results.Ok();
        });

        app.MapGet("/register/getGenders", async (AppDbContext dbContext) =>
        {
            List<Gender> allGenders = await dbContext.Gender.ToListAsync();

            return Results.Ok(allGenders);
        });

        app.MapGet("/register/getClans", async (AppDbContext dbContext) =>
        {
            List<Clan> allClans = await dbContext.Clan.ToListAsync();

            return Results.Ok(allClans);
        });

        app.MapGet("/register/{Id}", async (int Id, AppDbContext dbContext) =>
        {
            List<PersonClanRequest> allRequests = await dbContext.PersonClanRequest.Include(p => p.Person).Include(c => c.Clan).Where(x => x.RequestTypeID == Id).ToListAsync();
            var prs = new List<PersonStatus>();
            foreach (PersonClanRequest request in allRequests)
            {
                var pc = new PersonStatus
                {
                    PersonId = request.PersonID,
                    FullName = request.Person.FirstName + " " + request.Person.MiddleName + " " + request.Person.LastName,
                    ClanName = request.Clan.Name,
                    PersonClanRequestId = request.PersonClanRequestID
                };
                prs.Add(pc);
            }

            var dto = new PersonRegisterStatusDTO()
            {
                RequestTypeId = Id,
                PersonStatuses = prs
            };

            if (dto != null)
            {
                return Results.Ok(dto);
            }
            else
            {
                return Results.NotFound();
            }


            //if (allRequests.Count > 0)
            //{
            //    var prs = new List<PersonStatus>
            //    {
            //        PersonId = allRequests.
            //    }
            //}
            //PersonStatus pc = new PersonStatus()
            //{
            //    PersonId = 1,
            //    FullName = "Rohith R Athrey",
            //    ClanName = "Njovu"
            //};
            //var prs = new List<PersonStatus>();
            //prs.Add(pc);
            //pc = new PersonStatus()
            //{
            //    PersonId = 2,
            //    FullName = "Nisha R Athrey",
            //    ClanName = "Njovu"
            //};
            //prs.Add(pc);

            //var dto = new PersonRegisterStatusDTO()
            //{
            //    RequestTypeId = 1,
            //    PersonStatuses = prs
            //};

            //if (dto != null)
            //{
            //    return Results.Ok(dto);
            //}
            //else
            //{
            //    return Results.NotFound();
            //}


            //Person? person = await dbContext.PersonClanRequest.FindAsync(Id);

            //if (post != null)
            //{
            //    return Results.Ok(post);
            //}
            //else
            //{
            //    return Results.NotFound();
            //}
        });

        app.MapPost("/register", async (RegistrationDTO registrationDTO, AppDbContext dbContext) =>
        {
            // We have to insert into the following tables for a registration to be fulfilled
            // Person, PersonClanRequest
            // Let EF Core auto-increment the ID.
            PersonClanRequest pcr = new()
            {
                ClanID = registrationDTO.ClanID,
                RequestTypeID = 1, // Requested
                LastUpdatedDate = DateTime.Now,
                LastUpdatedBy = registrationDTO.FirstName + " " + registrationDTO.MiddleName + " " + registrationDTO.LastName,
            };
            var pcrs = new List<PersonClanRequest>
            {
                pcr
            };

            Person person = new()
            {
                PersonID = 0,
                LastName = registrationDTO.LastName,
                MiddleName = registrationDTO.MiddleName,
                FirstName = registrationDTO.FirstName,
                BirthDate = registrationDTO.BirthDate,
                Address = registrationDTO.Address,
                City = registrationDTO.City,
                Telephone = registrationDTO.Telephone,
                GenderID = registrationDTO.GenderID,
                Email = registrationDTO.Email,
                LoginId = registrationDTO.LoginId,
                Password = "1234",
                IsActive = true,
                IsUser = true,
                LastUpdatedDate = DateTime.Now,
                LastUpdatedBy = registrationDTO.FirstName + " " + registrationDTO.MiddleName + " " + registrationDTO.LastName,
                PersonClanRequests = pcrs
            };
            dbContext.Person.Add(person);
            bool success = await dbContext.SaveChangesAsync() > 0;
            if (success)
            {
                return Results.Ok(person.PersonID);
            }
            else
            {
                // 500 = internal server error.
                return Results.StatusCode(500);
            }
        });

        app.MapPut("/register/{Id}", async (int Id, UpdatedRequestDTO updatedRequestDTO, AppDbContext dbContext) =>
        {
            var requestToUpdate = await dbContext.PersonClanRequest.FindAsync(Id);

            if (requestToUpdate != null)
            {
                requestToUpdate.RequestTypeID = updatedRequestDTO.RequestTypeId;
                requestToUpdate.LastUpdatedBy = updatedRequestDTO.LastUpdatedBy;
                requestToUpdate.LastUpdatedDate = DateTime.Now;

                bool success = await dbContext.SaveChangesAsync() > 0;

                if (success)
                {
                    return Results.Ok(updatedRequestDTO);
                }
                else
                {
                    // 500 = internal server error.
                    return Results.StatusCode(500);
                }
            }
            else
            {
                return Results.NotFound();
            }
        });

        //app.MapDelete("/posts/{Id}", async (int Id, AppDbContext dbContext) =>
        //{
        //    Post? postToDelete = await dbContext.Posts.FindAsync(Id);

        //    if (postToDelete != null)
        //    {
        //        dbContext.Posts.Remove(postToDelete);

        //        bool success = await dbContext.SaveChangesAsync() > 0;

        //        if (success)
        //        {
        //            return Results.NoContent();
        //        }
        //        else
        //        {
        //            // 500 = internal server error.
        //            return Results.StatusCode(500);
        //        }
        //    }
        //    else
        //    {
        //        return Results.NotFound();
        //    }
        //});
    }
}
