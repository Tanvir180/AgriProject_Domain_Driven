using AgriTourismArchi.Aggregator.Models;
using AgriTourismArchi.DTO;
using AgriTourismArchi.Handler.Interfaces;
using AgriTourismArchi.Repository.Interfaces;

namespace AgriTourismArchi.Handler
{
    public class CategoryHandler : ICategoryHandler
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDTO> GetCategories(string searchString, DateTime? searchDate)
        {
            var categories = _categoryRepository.GetCategories(searchString, searchDate);
            return categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Location = c.Location,
                Cost = (decimal)c.Cost,
                Capacity = c.Capacity,
                Date = c.Date
            });
        }

        public CategoryDTO GetCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return null;
            }

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Location = category.Location,
                Cost = (decimal)category.Cost,
                Capacity = category.Capacity,
                Date = category.Date
            };
        }

        public void CreateCategory(CategoryDTO categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Location = categoryDto.Location,
                Cost = (double)categoryDto.Cost,
                Capacity = categoryDto.Capacity,
                Date = categoryDto.Date
            };
            _categoryRepository.AddCategory(category);
        }

        public void UpdateCategory(CategoryDTO categoryDto)
        {
            var category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Location = categoryDto.Location,
                Cost = (double)categoryDto.Cost,
                Capacity = categoryDto.Capacity,
                Date = categoryDto.Date
            };
            _categoryRepository.UpdateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
        }
    }
}
