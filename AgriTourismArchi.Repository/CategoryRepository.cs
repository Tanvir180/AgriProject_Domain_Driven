using AgriTourismArchi.Aggregator.Models;
using AgriTourismArchi.Repository.Data;
using AgriTourismArchi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgriTourismArchi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetCategories(string searchString, DateTime? searchDate)
        {
            var query = _dbContext.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(c => c.Name.Contains(searchString) || c.Location.Contains(searchString));
            }

            if (searchDate.HasValue)
            {
                query = query.Where(c => c.Date.Date == searchDate.Value.Date);
            }

            return query.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            // Check if the category is already tracked
            var existingCategory = _dbContext.Categories.Local.FirstOrDefault(c => c.Id == category.Id);

            if (existingCategory != null)
            {
                // Remove the existing entity from the context
                _dbContext.Entry(existingCategory).State = EntityState.Detached;
            }

            // Attach and update the entity
            _dbContext.Attach(category);
            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }


        public void DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
        }
    }
}
