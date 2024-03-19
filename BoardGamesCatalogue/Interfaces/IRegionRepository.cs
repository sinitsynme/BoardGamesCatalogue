using BoardGamesCatalogue.Models;

namespace BoardGamesCatalogue.Interfaces;

public interface IRegionRepository
{
    Task<List<Region>> GetAllRegions();
}