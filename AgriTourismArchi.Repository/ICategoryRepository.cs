using AgriTourismArchi.Aggregator.Models;

namespace AgriTourismArchi.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories(string searchString, DateTime? searchDate);
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
