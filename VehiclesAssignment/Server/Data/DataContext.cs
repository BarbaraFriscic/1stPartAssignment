
using VehiclesAssignment.Shared;

namespace VehiclesAssignment.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>().HasData(
                new VehicleMake
                {
                    Id = 1,
                    Name = "Alfa Romeo",
                    Abreviation = "ALFA",
                    
                },
                new VehicleMake
                {
                    Id = 2,
                    Name = "Chevrolet",
                    Abreviation = "CHEV"
                },
                new VehicleMake
                {
                    Id = 3,
                    Name = "Hyundai",
                    Abreviation = "HYUN"
                } 
                );

            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel
                {
                    Id = 1,
                    MakeID= 1,
                    Name = "031 Spider Roadsters",
                    Abreviation = "ALFA"
                    
                },
                new VehicleModel
                {
                    Id = 2,
                    MakeID = 2,
                    Name = "002 Impala/Caprice Belair",
                    Abreviation = "CHEV"
                },
                new VehicleModel
                {
                    Id = 3,
                    MakeID = 3,
                    Name = "036 Accent GT",
                    Abreviation = "HYUN"
                }
                );
        }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
    }
}
