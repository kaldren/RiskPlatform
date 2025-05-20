using Microsoft.EntityFrameworkCore;
using RiskPlatform.Modules.Bots.Domain.Entities;
using System.Reflection.Emit;

namespace RiskPlatform.Modules.Bots.Infrastructure.Persistence
{
    public class BotDbContext : DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options) { }

        public DbSet<Bot> Bots { get; set; }
        public DbSet<BotInput> Inputs { get; set; }
        public DbSet<BotOutput> Outputs { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<RunInput> RunInputs { get; set; }
        public DbSet<RunOutput> RunOutputs { get; set; }

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

                b.HasMany(x => x.BotInputs)
                 .WithOne(x => x.Bot)
                 .HasForeignKey(x => x.BotId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.BotOutputs)
                    .WithOne(x => x.Bot)
                    .HasForeignKey(x => x.BotId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.Runs)
                    .WithOne(x => x.Bot)
                    .HasForeignKey(x => x.BotId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            mb.Entity<BotInput>(p =>
            {
                p.ToTable("BotInputs").HasKey(x => x.Id);

                p.Property(x => x.Name)
                 .IsRequired().HasMaxLength(100);

                p.HasOne(x => x.Bot)
                    .WithMany(b => b.BotInputs)
                    .HasForeignKey(x => x.BotId);

                p.OwnsOne(x => x.Type, o =>
                    o.Property(t => t.Value)
                     .HasColumnName("FieldType")
                     .IsRequired()
                     .HasMaxLength(255));
            });

            mb.Entity<BotOutput>(o =>
            {
                o.ToTable("BotOutputs").HasKey(x => x.Id);

                o.Property(x => x.Name)
                 .IsRequired().HasMaxLength(255);

                o.HasOne(x => x.Bot)
                 .WithMany(b => b.BotOutputs)
                 .HasForeignKey(x => x.BotId);
            });

            mb.Entity<Run>(r =>
            {
                r.ToTable("Runs").HasKey(x => x.Id);
                r.Property(x => x.Status)
                 .IsRequired().HasMaxLength(255);
                r.HasOne(x => x.Bot)
                 .WithMany(b => b.Runs)
                 .HasForeignKey(x => x.BotId);
            });

            // RunInput
            mb.Entity<RunInput>(b =>
            {
                b.ToTable("RunInputs");

                b.HasKey(ri => ri.Id);

                b.Property(ri => ri.Value)
                 .IsRequired()
                 .HasMaxLength(1000);

                b.HasOne(ri => ri.Run)
                 .WithMany(r => r.RunInputs)
                 .HasForeignKey(ri => ri.RunId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(ri => ri.BotInput)
                 .WithMany(bi => bi.RunInputs)
                 .HasForeignKey(ri => ri.BotInputId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // RunOutput
            mb.Entity<RunOutput>(b =>
            {
                b.ToTable("RunOutputs");

                b.HasKey(ro => ro.Id);

                b.Property(ro => ro.Url)
                 .IsRequired()
                 .HasMaxLength(1000);

                b.HasOne(ro => ro.Run)
                 .WithMany(r => r.RunOutputs)
                 .HasForeignKey(ro => ro.RunId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(ro => ro.BotOutput)
                 .WithMany(bo => bo.RunOutputs)
                 .HasForeignKey(ro => ro.BotOutputId)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
