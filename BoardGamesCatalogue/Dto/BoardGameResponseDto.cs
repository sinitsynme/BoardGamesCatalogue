namespace BoardGamesCatalogue.Dto;

public class BoardGameResponseDto
{
    public int Id { get; set; }
    public string ShopNumber { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
    public String GameDurationInMinutes { get; set; }
    public String PlayersQuantity { get; set; }

    public IEnumerable<CategoryResponseDto> Categories { get; set; }
    public CreatorResponseDto Creator { get; set; }
    public string ImageUrl { get; set; }

}