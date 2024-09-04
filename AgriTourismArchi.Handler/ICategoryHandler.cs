using AgriTourismArchi.DTO;

namespace AgriTourismArchi.Handler.Interfaces
{
    public interface ICategoryHandler
    {
        IEnumerable<CategoryDTO> GetCategories(string searchString, DateTime? searchDate);
        CategoryDTO GetCategoryById(int id);
        void CreateCategory(CategoryDTO categoryDto);
        void UpdateCategory(CategoryDTO categoryDto);
        void DeleteCategory(int id);
    }
}
