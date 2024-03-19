using BoardGamesCatalogue.Dto;

namespace BoardGamesCatalogue.Interfaces;

public interface IBoardGameRepository
{
    Task<BoardGameResponseDto> GetBoardGameById(int id);
    Task<List<BoardGameResponseDto>> GetBoardGames();
    Task<List<BoardGameResponseDto>> GetBoardGamesFiltered(FilterDto filterDto);
    Task<BoardGameResponseDto> SaveBoardGame(BoardGameRequestDto requestDto);
}