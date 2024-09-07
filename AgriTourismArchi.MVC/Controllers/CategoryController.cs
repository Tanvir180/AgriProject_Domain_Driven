using AgriTourismArchi.DTO;
using AgriTourismArchi.Handler.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgriTourismArchi.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryHandler _categoryHandler;

        public CategoryController(ICategoryHandler categoryHandler)
        {
            _categoryHandler = categoryHandler;
        }


        // Mainly Used for search

        public IActionResult Index(string searchString, DateTime? searchDate)
        {
            var categories = _categoryHandler.GetCategories(searchString, searchDate);
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryHandler.CreateCategory(categoryDto);
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(categoryDto);
        }

        //Used for getting the specific category id 
        public IActionResult Edit(int id)
        {
            var category = _categoryHandler.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // It is used for Edit 

        [HttpPost]
        public IActionResult Edit(CategoryDTO categoryDto)
        {
            if (ModelState.IsValid)
            {
                _categoryHandler.UpdateCategory(categoryDto);
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(categoryDto);
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryHandler.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            _categoryHandler.DeleteCategory(id);
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var category = _categoryHandler.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}
