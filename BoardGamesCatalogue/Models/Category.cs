namespace BoardGamesCatalogue.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<BoardGameCategory> BoardGameCategories { get; set; }
}