namespace BoardGamesCatalogue.Dto;

public class BoardGameRequestDto
{
    public string ShopNumber { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
    public String GameDurationInMinutes { get; set; }
    public String PlayersQuantity { get; set; }

    public IEnumerable<int> CategoryIds { get; set; }
    public int CreatorId { get; set; }
    public string ImageUrl { get; set; }
}