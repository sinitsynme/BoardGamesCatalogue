using BoardGamesCatalogue.Data;
using BoardGamesCatalogue.Interfaces;
using BoardGamesCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesCatalogue.Repositories;

public class ShopAddressRepository(DataContext _context) : IShopAddressRepository
{
    public async Task<List<ShopAddress>> GetAllShopAddresses()
    {
        return await _context.ShopAddress.ToListAsync();
    }
}