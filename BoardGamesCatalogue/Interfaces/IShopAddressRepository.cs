using BoardGamesCatalogue.Models;

namespace BoardGamesCatalogue.Interfaces;

public interface IShopAddressRepository
{
    Task<List<ShopAddress>> GetAllShopAddresses();
}