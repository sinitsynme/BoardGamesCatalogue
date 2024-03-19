namespace BoardGamesCatalogue.Dto;

public class FilterDto
{
    public IEnumerable<int> CategoryIds { get; set; }
    public int CreatorId { get; set; }
    public decimal PriceFrom { get; set; }
    public decimal PriceTo { get; set; }
    public String PlayersQuantity { get; set; }
    public String Duration { get; set; }
}