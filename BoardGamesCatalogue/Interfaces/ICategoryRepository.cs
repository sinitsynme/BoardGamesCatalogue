using BoardGamesCatalogue.Models;

namespace BoardGamesCatalogue.Interfaces;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
}