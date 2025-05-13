
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiskPlatform.Modules.Bots.Domain.Entities;
using RiskPlatform.Modules.Bots.Domain.ValueObjects;

namespace RiskPlatform.Modules.Bots.Infrastructure.Persistence;
public class BotDbContext : DbContext
{
    public BotDbContext(DbContextOptions<BotDbContext> options) : base(options)
    {
    }

    public BotDbContext()
    {
    }

    public DbSet<Bot> Bots { get; set; }
    public DbSet<Script> Scripts { get; set; }
    public DbSet<InputParameter> InputFields { get; set; }
    public DbSet<InputFileParameter> InputFiles { get; set; }
    public DbSet<OutputFileParameter> OutputFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("BotsModule");

        // Bot
        modelBuilder.Entity<Bot>(builder =>
        {
            builder.ToTable("Bots");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.HasOne(x => x.Script)
                   .WithOne(x => x.Bot)
                   .HasForeignKey<Script>(x => x.BotId);

            builder.HasMany(x => x.InputFields)
                   .WithOne(x => x.Bot)
                   .HasForeignKey(x => x.BotId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.InputFiles)
                   .WithOne(x => x.Bot)
                   .HasForeignKey(x => x.BotId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.OutputFiles)
                   .WithOne(x => x.Bot)
                   .HasForeignKey(x => x.BotId)
                   .OnDelete(DeleteBehavior.Cascade);
        });

        // BotScript
        modelBuilder.Entity<Script>(builder =>
        {
            builder.ToTable("Scripts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FileUrl)
                   .IsRequired()
                   .HasMaxLength(500);
        });

        // BotInputField
        modelBuilder.Entity<InputParameter>(builder =>
        {
            builder.ToTable("InputParameters");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FieldName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.OwnsOne(x => x.FieldType, owned =>
            {
                owned.Property(p => p.Value)
                     .HasColumnName("FieldType")
                     .IsRequired()
                     .HasMaxLength(255);
            });
        });

        // BotInputFile
        modelBuilder.Entity<InputFileParameter>(builder =>
        {
            builder.ToTable("InputFileParameters");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsRequired)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.OwnsOne(x => x.FileExtension, owned =>
            {
                owned.Property(p => p.Value)
                     .HasColumnName("FileExtension")
                     .IsRequired()
                     .HasMaxLength(255);
            });
        });

        // BotOutputFile
        modelBuilder.Entity<OutputFileParameter>(builder =>
        {
            builder.ToTable("OutputFileParameters");
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.FileName, owned =>
            {
                owned.Property(p => p.Value)
                     .HasColumnName("FileName")
                     .IsRequired()
                     .HasMaxLength(255);
            });
        });

        base.OnModelCreating(modelBuilder);
    }
}