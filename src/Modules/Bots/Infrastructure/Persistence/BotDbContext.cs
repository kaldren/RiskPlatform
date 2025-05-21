using Microsoft.EntityFrameworkCore;
using RiskPlatform.Modules.Bots.Domain.Entities;
using RiskPlatform.Modules.Bots.Domain.ValueObjects;
using System.Reflection.Emit;

namespace RiskPlatform.Modules.Bots.Infrastructure.Persistence
{
    public class BotDbContext : DbContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options) { }

        public DbSet<Bot> Bots { get; set; }
        public DbSet<BotParameter> Parameters { get; set; }
        public DbSet<BotFile> Files { get; set; }
        public DbSet<BotRun> Runs { get; set; }
        public DbSet<BotRunParameter> RunParameters { get; set; }
        public DbSet<BotRunFile> RunFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.HasDefaultSchema("BotsModule");

            // Configure the entity mappings

            // Bot
            mb.Entity<Bot>(b =>
            {
                b.ToTable("Bots");

                b.HasKey(x => x.Id);

                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                b.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                b.Property(x => x.ScriptUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                b.Property(x => x.IsActive)
                    .IsRequired()
                    .HasDefaultValue(false);

                b.HasMany(x => x.Parameters)
                 .WithOne(x => x.Bot)
                 .HasForeignKey(x => x.BotId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.Files)
                 .WithOne(x => x.Bot)
                 .HasForeignKey(x => x.BotId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(x => x.Runs)
                 .WithOne(x => x.Bot)
                 .HasForeignKey(x => x.BotId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            mb.Entity<BotParameter>(b =>
            {
                b.ToTable("BotParameters");

                b.HasKey(x => x.Id);

                b.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                b.Property(x => x.DataType)
                    .IsRequired()
                    .HasConversion(
                        v => v.ToString(),
                        v => (ParameterDataType)Enum.Parse(typeof(ParameterDataType), v))
                    .HasMaxLength(50);

                b.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                b.Property(x => x.DefaultValue)
                    .HasMaxLength(500);

                b.Property(x => x.IsRequired)
                    .IsRequired()
                    .HasDefaultValue(false);
            });

            mb.Entity<BotFile>(b => {

                b.ToTable("BotFiles");

                b.HasKey(x => x.Id);

                b.Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                b.Property(x => x.FileType)
                    .IsRequired()
                    .HasConversion(
                        v => v.ToString(),
                        v => (FileType)Enum.Parse(typeof(FileType), v))
                    .HasMaxLength(50);

                b.Property(x => x.IsRequired)
                    .IsRequired()
                    .HasDefaultValue(false);
            });

            mb.Entity<BotRun>(b =>
            {
                b.ToTable("BotRuns");

                b.HasKey(x => x.Id);

                b.Property(x => x.Status)
                    .IsRequired()
                    .HasConversion(
                        v => v.ToString(),
                        v => (BotRunStatus)Enum.Parse(typeof(BotRunStatus), v))
                    .HasMaxLength(50);

                b.Property(x => x.StartedAt)
                    .IsRequired();

                b.Property(x => x.EndedAt)
                    .IsRequired();
            });

            mb.Entity<BotRunParameter>(b => {
                b.ToTable("BotRunParameters");

                b.HasKey(x => x.Id);

                b.Property(x => x.Value)
                    .IsRequired()
                    .HasMaxLength(500);

                b.HasOne(x => x.BotRun)
                  .WithMany()
                  .HasForeignKey(x => x.BotRunId)
                  .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(x => x.BotParameter)
                  .WithMany()
                  .HasForeignKey(x => x.BotParameterId)
                  .OnDelete(DeleteBehavior.Restrict);
            });

            mb.Entity<BotRunFile>(b =>
            {
                b.ToTable("BotRunFiles");

                b.HasKey(x => x.Id);

                b.Property(x => x.FileName)
                    .IsRequired()
                    .HasMaxLength(500);

                b.Property(x => x.Url)
                    .IsRequired()
                    .HasMaxLength(500);

                b.HasOne(x => x.BotRun)
                  .WithMany()
                  .HasForeignKey(x => x.BotRunId)
                  .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
