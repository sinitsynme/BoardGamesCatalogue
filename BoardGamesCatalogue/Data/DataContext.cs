using BoardGamesCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesCatalogue.Data;
 
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Creator> Creators { get; set; }
    public DbSet<BoardGame> BoardGames { get; set; }
    public DbSet<BoardGameCategory> BoardGameCategories { get; set; }
    public DbSet<Region> Region { get; set; }
    public DbSet<ShopAddress> ShopAddress { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BoardGameCategory>()
            .HasKey(bgc => new { bgc.BoardGameId, bgc.CategoryId });
        modelBuilder.Entity<BoardGameCategory>()
            .HasOne(b => b.BoardGame)
            .WithMany(bc => bc.BoardGameCategories)
            .HasForeignKey(b => b.BoardGameId);
        modelBuilder.Entity<BoardGameCategory>()
            .HasOne(c => c.Category)
            .WithMany(bc => bc.BoardGameCategories)
            .HasForeignKey(c => c.CategoryId);

        modelBuilder.Entity<Category>()
            .HasIndex(c => new { c.Name })
            .IsUnique();
        
        modelBuilder
            .Entity<BoardGame>()
            .Property(bg => bg.PlayersQuantity)
            .HasConversion(
                v => v.ToString(),
                v => (PlayersQuantity)Enum.Parse(typeof(PlayersQuantity), v));
        
        modelBuilder
            .Entity<BoardGame>()
            .Property(bg => bg.Duration)
            .HasConversion(
                v => v.ToString(),
                v => (GameDurationInMinutes)Enum.Parse(typeof(GameDurationInMinutes), v));

        modelBuilder
            .Entity<ShopAddress>()
            .HasKey(sa => new { sa.Id });
        
        modelBuilder
            .Entity<Region>()
            .HasKey(reg => new { reg.Name });
    }
    
}