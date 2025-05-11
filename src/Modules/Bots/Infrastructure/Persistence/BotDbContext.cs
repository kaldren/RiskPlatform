
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
    public DbSet<BotInputField> BotInputFields { get; set; }
    public DbSet<BotOutputFile> BotOutputFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entities here
        modelBuilder.HasDefaultSchema("BotsModule");
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
}

public class BotConfiguration : IEntityTypeConfiguration<Bot>
{
    public void Configure(EntityTypeBuilder<Bot> builder)
    {
        builder.ToTable("Bots");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasIndex(x => x.Name)
               .IsUnique(); // Bots should have unique names (need to check if this is correct)

        builder.Property(x => x.Description)
               .IsRequired()
               .HasMaxLength(500);

        builder.OwnsOne(x => x.ScriptFileName, owned =>
        {
            owned.Property(p => p.Value)
                 .HasColumnName("ScriptFileName")
                 .IsRequired()
                 .HasMaxLength(255);
        });
    }
}

public class BotInputFieldConfiguration : IEntityTypeConfiguration<BotInputField>
{
    public void Configure(EntityTypeBuilder<BotInputField> builder)
    {
        builder.ToTable("BotInputFields");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Bot)
               .WithMany(b => b.InputFields)
               .HasForeignKey(x => x.BotId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.FieldName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.FieldType)
               .IsRequired()
               .HasMaxLength(50);
    }
}

public class BotOutputFileConfiguration : IEntityTypeConfiguration<BotOutputFile>
{
    public void Configure(EntityTypeBuilder<BotOutputFile> builder)
    {
        builder.ToTable("BotOutputFiles");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Bot)
               .WithMany(b => b.OutputFiles)
               .HasForeignKey(x => x.BotId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(x => x.FileName, owned =>
        {
            owned.Property(p => p.Value)
                 .HasColumnName("FileName")
                 .IsRequired()
                 .HasMaxLength(255);
        });
    }
}