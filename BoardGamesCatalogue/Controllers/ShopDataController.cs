using BoardGamesCatalogue.Interfaces;
using BoardGamesCatalogue.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesCatalogue.Controllers;

[Route("/rest/api/[controller]")]
[ApiController]
public class ShopDataController(IShopAddressRepository _shopAddressRepository) : Controller
{
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ShopAddress>))]
    public async Task<IActionResult> GetBoardGames()
    {
        var boardGames = await _shopAddressRepository.GetAllShopAddresses();

        return Ok(boardGames);
    }
    
}