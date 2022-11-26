using Microsoft.EntityFrameworkCore;

namespace Rocket_Elevators_Rest_API.Models
{
    public class RocketElevatorsContext : DbContext
    {
        public RocketElevatorsContext(DbContextOptions<RocketElevatorsContext> options)
            : base(options)
        {
        }

        public DbSet<Battery> batteries { get; set; } = null!;
        public DbSet<Column> columns { get; set; } = null!;
        public DbSet<Elevator> elevators { get; set; } = null!;
        public DbSet<Lead> leads { get; set; } = null!;
        public DbSet<Customer> customers { get; set; } = null!;
        public DbSet<Building> buildings { get; set; } = null!;
        public DbSet<Intervention> interventions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=ls-f2d6bd226744c0fcfc2009d804298a21ce412d05.crydppxblqbm.ca-central-1.rds.amazonaws.com;port=3306;database=myapp_development;uid=hello;password=Iloverails1!", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8mb3");
                 modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.contactBuisnessName)
                    .HasMaxLength(255)
                    .HasColumnName("contactBuisnessName");
                entity.Property(e => e.created_at)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");
                entity.Property(e => e.contactDepartement)
                    .HasMaxLength(255)
                    .HasColumnName("contactDepartement");
                entity.Property(e => e.projectDescription)
                    .HasMaxLength(255)
                    .HasColumnName("projectDescription");
                entity.Property(e => e.contactEmail)
                    .HasMaxLength(255)
                    .HasColumnName("contactEmail");
                entity.Property(e => e.contactName)
                    .HasMaxLength(255)
                    .HasColumnName("contactName");
                entity.Property(e => e.message)
                    .HasMaxLength(255)
                    .HasColumnName("message");
                entity.Property(e => e.projectName)
                    .HasMaxLength(255)
                    .HasColumnName("projectName");
                entity.Property(e => e.contactPhone)
                    .HasMaxLength(255)
                    .HasColumnName("contactPhone");
                entity.Property(e => e.updated_at)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

        }

    }
}
