using BoardGamesCatalogue.Dto;
using BoardGamesCatalogue.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoardGamesCatalogue.Controllers;

[Route("/rest/api/[controller]")]
[ApiController]
public class BoardGameController : Controller
{
    private readonly IBoardGameRepository _boardGameRepository;

    public BoardGameController(IBoardGameRepository boardGameRepository)
    {
        _boardGameRepository = boardGameRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<BoardGameResponseDto>))]
    public async Task<IActionResult> GetBoardGames()
    {
        var boardGames = await _boardGameRepository.GetBoardGames();

        return Ok(boardGames);
    }

    [HttpGet("filter")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<BoardGameResponseDto>))]
    public async Task<IActionResult> GetBoardGamesFiltered(
        [FromQuery] int[] categoryIds,
        int creatorId,
        decimal priceFrom,
        decimal priceTo,
        String playersQuantity = "",
        String duration = ""
    )
    {
        var filterDto = new FilterDto
        {
            CategoryIds = categoryIds,
            CreatorId = creatorId,
            PriceFrom = priceFrom,
            PriceTo = priceTo,
            PlayersQuantity = playersQuantity,
            Duration = duration
        };
        var boardGames = await _boardGameRepository.GetBoardGamesFiltered(filterDto);

        return Ok(boardGames);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(BoardGameResponseDto))]
    public async Task<IActionResult> GetBoardGameById(int id)
    {
        var boardGame = await _boardGameRepository.GetBoardGameById(id);

        return Ok(boardGame);
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(BoardGameResponseDto))]
    public async Task<IActionResult> SaveBoardGame(BoardGameRequestDto boardGameRequestDto)
    {
        var boardGame = await _boardGameRepository.SaveBoardGame(boardGameRequestDto);
        return Ok(boardGame);
    }
}