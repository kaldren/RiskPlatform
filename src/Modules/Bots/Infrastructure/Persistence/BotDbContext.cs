using Microsoft.EntityFrameworkCore;
using RiskPlatform.Modules.Bots.Domain.Entities;

namespace RiskPlatform.Modules.Bots.Infrastructure.Persistence
{
    public class BotDbContext : DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options) { }

        public DbSet<Bot> Bots { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<Runs> Runs { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.HasDefaultSchema("BotsModule");

            mb.Entity<Bot>(b =>
            {
                b.ToTable("Bots").HasKey(x => x.Id);

                b.Property(x => x.Name)
                    .IsRequired().HasMaxLength(100);
                b.HasIndex(x => x.Name).IsUnique();

                b.Property(x => x.Description)
                    .IsRequired().HasMaxLength(500);

                b.Property(x => x.ScriptUrl)
                    .IsRequired().HasMaxLength(500);

                b.HasMany(x => x.Inputs)
                 .WithOne(x => x.Bot)
                 .HasForeignKey(x => x.BotId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.Outputs)
                    .WithOne(x => x.Bot)
                    .HasForeignKey(x => x.BotId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.Runs)
                    .WithOne(x => x.Bot)
                    .HasForeignKey(x => x.BotId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            mb.Entity<Input>(p =>
            {
                p.ToTable("Inputs").HasKey(x => x.Id);

                p.Property(x => x.Name)
                 .IsRequired().HasMaxLength(100);

                p.OwnsOne(x => x.Type, o =>
                    o.Property(t => t.Value)
                     .HasColumnName("FieldType")
                     .IsRequired()
                     .HasMaxLength(255));
            });

            mb.Entity<Output>(o =>
            {
                o.ToTable("Outputs").HasKey(x => x.Id);

                o.Property(x => x.Name)
                 .IsRequired().HasMaxLength(255);

                o.HasOne(x => x.Bot)
                 .WithMany(b => b.Outputs)
                 .HasForeignKey(x => x.BotId);
            });

            mb.Entity<Runs>(r =>
            {
                r.ToTable("Runs").HasKey(x => x.Id);
                r.Property(x => x.Status)
                 .IsRequired().HasMaxLength(255);
                r.HasOne(x => x.Bot)
                 .WithMany(b => b.Runs)
                 .HasForeignKey(x => x.BotId);
            });
        }
    }
}
