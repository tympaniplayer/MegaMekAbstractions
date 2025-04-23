using MegaMekDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaMekDb.Data;

/// <summary>
/// Database context for the MegaMek database
/// </summary>
public class MechDbContext : DbContext
{
    public MechDbContext(DbContextOptions<MechDbContext> options) : base(options)
    {
    }
    
    public DbSet<MechEntity> Mechs { get; set; } = null!;
    public DbSet<QuirkEntity> Quirks { get; set; } = null!;
    public DbSet<ArmorValueEntity> ArmorValues { get; set; } = null!;
    public DbSet<StructureValueEntity> StructureValues { get; set; } = null!;
    public DbSet<EquipmentEntity> Equipment { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure MechEntity
        modelBuilder.Entity<MechEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => new { e.Chassis, e.Model }).IsUnique();
            entity.HasIndex(e => e.FileHash).IsUnique();
            
            // Configure relationships
            entity.HasMany(e => e.Quirks)
                .WithOne(e => e.Mech)
                .HasForeignKey(e => e.MechEntityId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasMany(e => e.ArmorValues)
                .WithOne(e => e.Mech)
                .HasForeignKey(e => e.MechEntityId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasMany(e => e.StructureValues)
                .WithOne(e => e.Mech)
                .HasForeignKey(e => e.MechEntityId)
                .OnDelete(DeleteBehavior.Cascade);
                
            entity.HasMany(e => e.Equipment)
                .WithOne(e => e.Mech)
                .HasForeignKey(e => e.MechEntityId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        // Configure indexes for child entities
        modelBuilder.Entity<QuirkEntity>().HasKey(e => e.Id);
        modelBuilder.Entity<QuirkEntity>().HasIndex(e => new { e.MechEntityId, e.Quirk }).IsUnique();
        
        modelBuilder.Entity<ArmorValueEntity>().HasKey(e => e.Id);
        modelBuilder.Entity<ArmorValueEntity>().HasIndex(e => new { e.MechEntityId, e.Location }).IsUnique();
        
        modelBuilder.Entity<StructureValueEntity>().HasKey(e => e.Id);
        modelBuilder.Entity<StructureValueEntity>().HasIndex(e => new { e.MechEntityId, e.Location }).IsUnique();
        
        modelBuilder.Entity<EquipmentEntity>().HasKey(e => e.Id);
        modelBuilder.Entity<EquipmentEntity>().HasIndex(e => new { e.MechEntityId, e.Location, e.Name });
    }
}
