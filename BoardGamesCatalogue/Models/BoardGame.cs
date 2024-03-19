namespace BoardGamesCatalogue.Models;

public class BoardGame
{
    public int Id { get; set; }
    public string ShopNumber { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public GameDurationInMinutes Duration { get; set; }
    public ICollection<BoardGameCategory> BoardGameCategories { get; set; }
    public Creator Creator { get; set; }
    public PlayersQuantity PlayersQuantity { get; set; }

    public BoardGame()
    {
    }

    public BoardGame(
        string shopNumber,
        decimal price,
        string name,
        GameDurationInMinutes duration,
        ICollection<BoardGameCategory> categories,
        Creator creator,
        PlayersQuantity playersQuantity,
        string imageUrl)
    {
        ShopNumber = shopNumber;
        Price = price;
        Name = name;
        Duration = duration;
        BoardGameCategories = categories;
        Creator = creator;
        PlayersQuantity = playersQuantity;
        ImageUrl = imageUrl;
    }
}