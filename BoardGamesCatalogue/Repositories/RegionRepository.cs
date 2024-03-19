using BoardGamesCatalogue.Data;
using BoardGamesCatalogue.Interfaces;
using BoardGamesCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesCatalogue.Repositories;

public class RegionRepository(DataContext _context) : IRegionRepository
{
    public async Task<List<Region>> GetAllRegions()
    {
        return await _context.Region.ToListAsync();
    }
}