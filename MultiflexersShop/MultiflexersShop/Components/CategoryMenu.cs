using Microsoft.AspNetCore.Mvc;
using MultiflexersShop.Models.Interfaces;
using System.Linq;

namespace MultiflexersShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private ICategoryRepository categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryRepository.Categories.OrderBy(n => n.CategoryName);

            return View(categories);
        }
    }
}
