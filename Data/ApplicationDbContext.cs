using Microsoft.EntityFrameworkCore;
using Car_Mod_net.Models;

namespace Car_Mod_net.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<ModPart> ModParts { get; set; } = null!;
        public DbSet<VehicleModPart> VehicleModParts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Key for many-to-many join table
            modelBuilder.Entity<VehicleModPart>()
                .HasKey(vmp => new { vmp.VehicleId, vmp.ModPartId });

            modelBuilder.Entity<VehicleModPart>()
                .HasOne(vmp => vmp.Vehicle)
                .WithMany(v => v.VehicleModParts)
                .HasForeignKey(vmp => vmp.VehicleId);

            modelBuilder.Entity<VehicleModPart>()
                .HasOne(vmp => vmp.ModPart)
                .WithMany(mp => mp.VehicleModParts)
                .HasForeignKey(vmp => vmp.ModPartId);

            // Seed Vehicles
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Make = "Honda", Model = "Civic Type R", Year = 2023 },
                new Vehicle { Id = 2, Make = "Porsche", Model = "911 GT3 RS", Year = 2024 },
                new Vehicle { Id = 3, Make = "Nissan", Model = "GT-R (R35)", Year = 2022 },
                new Vehicle { Id = 4, Make = "Toyota", Model = "GR Supra", Year = 2023 }
            );

            // Seed ModParts
            modelBuilder.Entity<ModPart>().HasData(
                new ModPart { Id = 1, Category = "Body Kit", Name = "Vented Carbon Fiber Hood", Price = 1850.00m, ImageUrl = "/images/carbon-hood.jpg" },
                new ModPart { Id = 2, Category = "Wheels", Name = "Forged Monoblock Track Wheels", Price = 4200.00m, ImageUrl = "/images/forged-wheels.jpg" },
                new ModPart { Id = 3, Category = "Custom Paint", Name = "Satin Liquid Chrome Wrap", Price = 3500.00m, ImageUrl = "/images/chrome-wrap.jpg" },
                new ModPart { Id = 4, Category = "Body Kit", Name = "Carbon Rear Wing Spoiler", Price = 2200.00m, ImageUrl = "/images/rear-wing.jpg" },
                new ModPart { Id = 5, Category = "Window Tint", Name = "Ceramic Infrared Stealth Tint", Price = 650.00m, ImageUrl = "/images/stealth-tint.jpg" },
                new ModPart { Id = 6, Category = "Exhaust", Name = "Titanium Active Valve Exhaust", Price = 3800.00m, ImageUrl = "/images/titanium-exhaust.jpg" }
            );

            // Seed VehicleModParts compatibility mapping
            modelBuilder.Entity<VehicleModPart>().HasData(
                // Carbon Hood compatibility: Civic Type R (1), GT-R (3), GR Supra (4)
                new VehicleModPart { VehicleId = 1, ModPartId = 1 },
                new VehicleModPart { VehicleId = 3, ModPartId = 1 },
                new VehicleModPart { VehicleId = 4, ModPartId = 1 },

                // Forged Wheels compatibility: All vehicles
                new VehicleModPart { VehicleId = 1, ModPartId = 2 },
                new VehicleModPart { VehicleId = 2, ModPartId = 2 },
                new VehicleModPart { VehicleId = 3, ModPartId = 2 },
                new VehicleModPart { VehicleId = 4, ModPartId = 2 },

                // Chrome Wrap compatibility: All vehicles
                new VehicleModPart { VehicleId = 1, ModPartId = 3 },
                new VehicleModPart { VehicleId = 2, ModPartId = 3 },
                new VehicleModPart { VehicleId = 3, ModPartId = 3 },
                new VehicleModPart { VehicleId = 4, ModPartId = 3 },

                // Carbon Rear Wing compatibility: 911 GT3 RS (2), GT-R (3), GR Supra (4)
                new VehicleModPart { VehicleId = 2, ModPartId = 4 },
                new VehicleModPart { VehicleId = 3, ModPartId = 4 },
                new VehicleModPart { VehicleId = 4, ModPartId = 4 },

                // Stealth Tint compatibility: All vehicles
                new VehicleModPart { VehicleId = 1, ModPartId = 5 },
                new VehicleModPart { VehicleId = 2, ModPartId = 5 },
                new VehicleModPart { VehicleId = 3, ModPartId = 5 },
                new VehicleModPart { VehicleId = 4, ModPartId = 5 },

                // Titanium Exhaust compatibility: 911 GT3 RS (2), GT-R (3), GR Supra (4)
                new VehicleModPart { VehicleId = 2, ModPartId = 6 },
                new VehicleModPart { VehicleId = 3, ModPartId = 6 },
                new VehicleModPart { VehicleId = 4, ModPartId = 6 }
            );
        }
    }
}
