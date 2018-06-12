using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopTutorial.Data.Interfaces;
using WebShopTutorial.Data.Models;

namespace WebShopTutorial.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName = "Smartphones", Description = "Smartphones"},
                    new Category{CategoryName = "Tablets", Description = "Tablets"},
                    new Category{CategoryName = "Laptops", Description = "Laptops"},
                    new Category{CategoryName = "Wearable Technology", Description = "Smart watches, fintness trackers and stuff"}
                };
            }
        }
    }
}
