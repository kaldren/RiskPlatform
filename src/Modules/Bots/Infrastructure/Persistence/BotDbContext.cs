
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RiskPlatform.Modules.Bots.Domain.Entities;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entities here
        modelBuilder.ApplyConfiguration(new BotConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}

public class BotConfiguration : IEntityTypeConfiguration<Bot>
{
    public void Configure(EntityTypeBuilder<Bot> builder)
    {
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
