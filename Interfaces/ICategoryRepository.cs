using ReviewApp.Models;

namespace ReviewApp.Interfaces;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    ICollection<Pokemon> GetPokemonsByCategory(int categoryId);
    bool categoryExists(int id);
    bool CreateCategory(Category category);
    bool Save();
}