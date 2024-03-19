namespace BoardGamesCatalogue.Models;

public class BoardGameCategory
{
    public int BoardGameId { get; set; }
    public int CategoryId { get; set; }
    public BoardGame BoardGame { get; set; }
    public Category Category { get; set; }
    
}