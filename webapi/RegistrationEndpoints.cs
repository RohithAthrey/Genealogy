using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.IO;
using System.Net.Http.Headers;
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
        app.MapGet("/register/getClanHouses", async (AppDbContext dbContext) =>
        {
            List<ClanHouse> allClanHouses = await dbContext.ClanHouse.ToListAsync();

            return Results.Ok(allClanHouses);
        });

        app.MapGet("/register/{Id}", async (int Id, AppDbContext dbContext) =>
        {
            List<PersonClanHouseRequest> allRequests = await dbContext.PersonClanHouseRequest.Include(p => p.Person).Include(c => c.ClanHouse).Where(x => x.RequestTypeID == Id).ToListAsync();
            var prs = new List<PersonStatus>();
            foreach (PersonClanHouseRequest request in allRequests)
            {
                var pc = new PersonStatus
                {
                    PersonId = request.PersonID,
                    FullName = request.Person.FirstName + " " + request.Person.MiddleName + " " + request.Person.LastName,
                    ProfilePicPath = request.Person.ProfilePicPath,
                    ClanHouseName = request.ClanHouse.ClanHouseName,
                    PersonClanHouseRequestId = request.PersonClanHouseRequestID,
                    RegisterPara = request.Person.RegisterPara,
                    Grandparents = request.Person.Grandparents,
                    Parents = request.Person.Parents,
                    GreatGrandparents = request.Person.GreatGrandparents
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
        });

        app.MapPost("/register", async (RegistrationDTO registrationDTO, AppDbContext dbContext) =>
        {
            // We have to insert into the following tables for a registration to be fulfilled
            // Person, PersonClanHouseRequest
            // Let EF Core auto-increment the ID.
            PersonClanHouseRequest pcr = new()
            {
                ClanHouseID = registrationDTO.ClanHouseID,
                RequestTypeID = 1, // Requested
                LastUpdatedDate = DateTime.Now,
                LastUpdatedBy = registrationDTO.FirstName + " " + registrationDTO.MiddleName + " " + registrationDTO.LastName,
            };
            var pcrs = new List<PersonClanHouseRequest>
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
                Password = registrationDTO.Password,
                ProfilePicPath = registrationDTO.ProfilePicPath,
                RegisterPara = registrationDTO.RegisterPara,
                Grandparents = registrationDTO.Grandparents,
                Parents = registrationDTO.Parents,
                GreatGrandparents = registrationDTO.GreatGrandparents,
                ClanHouseID=registrationDTO.ClanHouseID,
                IsActive = false,
                IsUser = true,
                LastUpdatedDate = DateTime.Now,
                LastUpdatedBy = registrationDTO.FirstName + " " + registrationDTO.MiddleName + " " + registrationDTO.LastName,
                PersonClanHouseRequests = pcrs
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
        // first update the person and make the person active (IsActive flag in the db)
        var person = await dbContext.Person.FindAsync(updatedRequestDTO.PersonId);
        if (person != null)
        {
            if (updatedRequestDTO.RequestTypeId == 2)
                {
                    person.IsActive = true;
                }
            // next update the PersonClanHouseRequest table to set the flag to approved
            var requestToUpdate = await dbContext.PersonClanHouseRequest.FindAsync(Id);
            if (requestToUpdate != null)
            {
                requestToUpdate.RequestTypeID = updatedRequestDTO.RequestTypeId;
                requestToUpdate.LastUpdatedBy = updatedRequestDTO.LastUpdatedBy;
                requestToUpdate.LastUpdatedDate = DateTime.Now;

                if (requestToUpdate.RequestTypeID == 2)
                {
                    PersonRole personRole = new()
                    {
                        PersonID = updatedRequestDTO.PersonId,
                        RoleID = 2,
                        IsActive = true,
                        LastUpdatedDate = DateTime.Now,
                        LastUpdatedBy = updatedRequestDTO.LastUpdatedBy

                    };
                        dbContext.PersonRole.Add(personRole);
                    }

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
            }
            else
            {
                return Results.NotFound();
            }
        });

        app.MapPost("/register/upload", async (IFormFile file) =>
        {
            var folderName = Path.Combine("Resources", "Images");
            var folderOuterName = "Resources";
            var folderInnerName = "Images";
            if (!Directory.Exists(folderOuterName))
            {
                DirectoryInfo dout = Directory.CreateDirectory(folderOuterName);
                DirectoryInfo din = Directory.CreateDirectory(folderInnerName);
            } else
            {
                if (!Directory.Exists(folderInnerName))
                {
                    DirectoryInfo din = Directory.CreateDirectory(folderInnerName);
                }
            }
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            try
            {
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var profilePicPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return Results.Ok(new { profilePicPath });
                }
                else
                {
                    // 500 = internal server error.
                    return Results.BadRequest();
                }
            }
            catch
            {
                // 500 = internal server error.
                return Results.StatusCode(500);
            }
        });
        app.MapPut("/register/updateProfilePicPath/{userId}", async (IFormFile file, int userId, AppDbContext dbContext) =>
        {
            // Retrieve the user record based on the provided userId
            var user = await dbContext.Person.FindAsync(userId);// Retrieve the user based on the userId

            if (user == null)
            {
                // Return an appropriate response indicating that the user was not found
                return Results.NotFound();
            }

            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            try
            {
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var profilePicPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    user.ProfilePicPath = profilePicPath;
                    bool success = await dbContext.SaveChangesAsync() > 0; 
                    if (success)
                    {
                        return Results.Ok(new { profilePicPath });
                    }
                    else
                    {
                        return Results.StatusCode(500);
                    }

                }
                else
                {
                    // 400 = bad request.
                    return Results.BadRequest();
                }
            }
            catch
            {
                // 500 = internal server error.
                return Results.StatusCode(500);
            }
        });

        app.MapGet("/register/getProfileInfo/{Id}", async (int Id, AppDbContext dbContext) =>
        {
            var person = await dbContext.Person.FindAsync(Id);
            if (person != null)
            {
                ProfileScreenDTO userInfo = new()
                {
                    About = person.RegisterPara,
                    Surname = person.LastName,
                    MiddleName = person.MiddleName,
                    FirstName = person.FirstName,
                    Email = person.Email,
                    Phone = person.Telephone,
                    ProfilePicPath = person.ProfilePicPath
                };
                return Results.Ok(userInfo);
                }

                else
                {
                    // 500 = internal server error.
                    return Results.StatusCode(500);
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
