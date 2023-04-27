using Microsoft.EntityFrameworkCore;
using RobotApocalypse.Models;

namespace RobotApocalypse.Data
{
    public class RobotContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public RobotContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("RobotApocalypseDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasData(
                new Resource { Id=1, Name="Water"},
                new Resource { Id=2,Name="Food"},
                new Resource { Id=3,Name="Medication"},
                new Resource { Id=4,Name="Ammunition"}
                );

            modelBuilder.Entity<Survivor>().HasMany(s => s.Resources).WithMany();

            modelBuilder.Entity<SurvivorResource>()
                .HasKey(sr => new { sr.SurvivorId, sr.ResourceId });

            modelBuilder.Entity<ReportedInfection>()
                .HasOne(r => r.Reporter)
                .WithMany(s => s.InfectionReports)
                .HasForeignKey(r => r.ReporterId);

            modelBuilder.Entity<ReportedInfection>()
                .HasKey(ri => new { ri.ReporterId, ri.InfectedSurvivorId });
        }

        public DbSet<Survivor> Survivors { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<ReportedInfection> ReportedInfections { get; set; }

        public DbSet<SurvivorResource> SurvivorResources { get; set; }
    }
}
