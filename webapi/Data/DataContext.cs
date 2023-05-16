using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using webapi.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace webapi.Data
{
    public class AppDbContext : DbContext
    {
        // We use => (expression-bodied members) to avoid nullable reference types errors.
        // Source: https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types#dbcontext-and-dbset.

        //Command to create db migration script
        //dotnet ef migrations add FirstMigration -o "Data/Migrations"
        //dotnet ef database update"
        public DbSet<Gender> Gender => Set<Gender>();
        public DbSet<Person> Person => Set<Person>();
        public DbSet<Clan> Clan => Set<Clan>();
        public DbSet<RequestType> RequestType => Set<RequestType>();
        public DbSet<PersonClanRequest> PersonClanRequest => Set<PersonClanRequest>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base version of this method (in DbContext) as well, else we sometimes get an error later on.
            base.OnModelCreating(modelBuilder);

            var gendersToSeed = new Gender[2];
            gendersToSeed[0] = new()
            {
                GenderID = 1,      
                GenderCode = "M",
                GenderValue = "Male"
            };
            gendersToSeed[1] = new()
            {
                GenderID = 2,
                GenderCode = "F",
                GenderValue = "Female"
            };
            modelBuilder.Entity<Gender>().HasData(gendersToSeed);

            var reqTypesToSeed = new RequestType[3];
            reqTypesToSeed[0] = new()
            {
                RequestTypeID = 1,
                RequestTypeCode = "R",
                RequestTypeValue = "Requested"
            };
            reqTypesToSeed[1] = new()
            {
                RequestTypeID = 2,
                RequestTypeCode = "A",
                RequestTypeValue = "Approved"
            };
            reqTypesToSeed[2] = new()
            {
                RequestTypeID = 3,
                RequestTypeCode = "D",
                RequestTypeValue = "Declined"
            };
            modelBuilder.Entity<RequestType>().HasData(reqTypesToSeed);

            var personsToSeed = new Person[1];
            personsToSeed[0] = new()
            {
                PersonID = 1,
                LastName = "Odombe",
                MiddleName = "R",
                FirstName = "Kenneth",
                BirthDate = "01/1970",
                Address = "123 Unknown Street",
                City = "Johanesburg",
                Telephone = "1234567890",
                GenderID = 1,
                Email = "kenny@unknown.com",
                LoginId = "kenny",
                Password = "1234",
                IsActive = true,
                IsUser = true,
                LastUpdatedDate = Convert.ToDateTime(DateTime.Now),
                LastUpdatedBy = "Kenneth R Odombe"
            };
            modelBuilder.Entity<Person>().HasData(personsToSeed);

            var clansToSeed = new Clan[1];
            clansToSeed[0] = new()
            {
                ClanID = 1,
                Name = "Njovu",
                Symbol = "Elephant",
                SubTotem = "Hippopotamus"
            };
            modelBuilder.Entity<Clan>().HasData(clansToSeed);
        }
    }
}
