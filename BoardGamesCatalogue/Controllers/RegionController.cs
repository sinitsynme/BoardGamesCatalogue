using BoardGamesCatalogue.Interfaces;
using BoardGamesCatalogue.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesCatalogue.Controllers;

[Route("/rest/api/[controller]")]
[ApiController]
public class RegionController(IRegionRepository _regionRepository): Controller
{
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Region>))]
    public async Task<IActionResult> GetBoardGames()
    {
        var boardGames = await _regionRepository.GetAllRegions();

        return Ok(boardGames);
    }
}