using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebShopNetCore2.Models.Interfaces;

namespace WebShopNetCore2.Components
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
