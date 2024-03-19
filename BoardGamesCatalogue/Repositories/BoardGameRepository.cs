using BoardGamesCatalogue.Data;
using BoardGamesCatalogue.Dto;
using BoardGamesCatalogue.Interfaces;
using BoardGamesCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesCatalogue.Repositories;

public class BoardGameRepository : IBoardGameRepository
{
    private readonly DataContext _context;

    public BoardGameRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<BoardGameResponseDto> GetBoardGameById(int id)
    {
        return await _context.BoardGames
            .Where(bg => bg.Id == id)
            .Include(b => b.Creator)
            .Include(b => b.BoardGameCategories)
            .ThenInclude(bc => bc.Category)
            .Select(x => new BoardGameResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    ShopNumber = x.ShopNumber,
                    Price = x.Price,
                    Creator = new CreatorResponseDto()
                    {
                        Id = x.Creator.Id,
                        Name = x.Creator.Name
                    },
                    PlayersQuantity = x.PlayersQuantity.ToString(),
                    GameDurationInMinutes = x.Duration.ToString(),
                    Categories = x.BoardGameCategories.Select(y => y.Category)
                        .Select(c => new CategoryResponseDto
                        {
                            Id = c.Id,
                            Name = c.Name
                        })
                }
            )
            .FirstOrDefaultAsync();
    }

    public async Task<List<BoardGameResponseDto>> GetBoardGames()
    {
        return await _context.BoardGames
            .OrderBy(b => b.Id)
            .Include(b => b.Creator)
            .Include(b => b.BoardGameCategories)
            .ThenInclude(bc => bc.Category)
            .Select(x => new BoardGameResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                    ShopNumber = x.ShopNumber,
                    Price = x.Price,
                    Creator = new CreatorResponseDto()
                    {
                        Id = x.Creator.Id,
                        Name = x.Creator.Name
                    },
                    PlayersQuantity = x.PlayersQuantity.ToString(),
                    GameDurationInMinutes = x.Duration.ToString(),
                    Categories = x.BoardGameCategories.Select(y => y.Category)
                        .Select(c => new CategoryResponseDto
                        {
                            Id = c.Id,
                            Name = c.Name
                        })
                }
            )
            .ToListAsync();
    }

    public async Task<List<BoardGameResponseDto>> GetBoardGamesFiltered(FilterDto filterDto)
    {
        return await _context.BoardGames
            .OrderBy(b => b.Id)
            .Include(b => b.Creator)
            .Include(b => b.BoardGameCategories)
            .ThenInclude(bc => bc.Category)
            .Where(bg => filterDto.CreatorId == 0 || bg.Creator.Id == filterDto.CreatorId)
            .Where(bg =>
                filterDto.PriceFrom == 0 && filterDto.PriceTo == 0 ||
                filterDto.PriceFrom <= bg.Price && bg.Price <= filterDto.PriceTo)
            .Where(bg =>
                filterDto.PlayersQuantity == String.Empty || bg.PlayersQuantity == (PlayersQuantity) Enum.Parse(typeof(PlayersQuantity), filterDto.PlayersQuantity))
            .Where(bg => filterDto.Duration == String.Empty || bg.Duration == (GameDurationInMinutes) Enum.Parse(typeof(GameDurationInMinutes), filterDto.Duration))
            .Where(bg =>
                filterDto.CategoryIds.All(id => bg.BoardGameCategories.Select(y => y.Category)
                    .Where(y => filterDto.CategoryIds.Count() == 0 || filterDto.CategoryIds.Contains(y.Id))
                    .Select(it => it.Id).Contains(id))
            )
            .Select(x => new BoardGameResponseDto
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Name = x.Name,
                    ShopNumber = x.ShopNumber,
                    Price = x.Price,
                    Creator = new CreatorResponseDto()
                    {
                        Id = x.Creator.Id,
                        Name = x.Creator.Name
                    },
                    PlayersQuantity = x.PlayersQuantity.ToString(),
                    GameDurationInMinutes = x.Duration.ToString(),
                    Categories = x.BoardGameCategories.Select(y => y.Category)
                        .Select(c => new CategoryResponseDto
                        {
                            Id = c.Id,
                            Name = c.Name
                        })
                }
            ).ToListAsync();
    }

    public async Task<BoardGameResponseDto> SaveBoardGame(BoardGameRequestDto requestDto)
    {
        var boardGame = new BoardGame();

        var categories = _context.Categories.Where(c => requestDto.CategoryIds.Contains(c.Id)).ToList();
        boardGame.BoardGameCategories =
            categories.Select(it => new BoardGameCategory { BoardGame = boardGame, Category = it }).ToList();

        var creator = _context.Creators.Where(c => c.Id == requestDto.CreatorId).FirstOrDefault();
        boardGame.Creator = creator;
        boardGame.Name = requestDto.Name;
        boardGame.ImageUrl = requestDto.ImageUrl;
        boardGame.Price = requestDto.Price;
        boardGame.ShopNumber = requestDto.ShopNumber;
        boardGame.Duration =
            (GameDurationInMinutes)Enum.Parse(typeof(GameDurationInMinutes), requestDto.GameDurationInMinutes);
        boardGame.PlayersQuantity = (PlayersQuantity)Enum.Parse(typeof(PlayersQuantity), requestDto.PlayersQuantity);
        _context.BoardGames.Add(boardGame);
        _context.SaveChanges();

        return await GetBoardGameById(boardGame.Id);
    }
}