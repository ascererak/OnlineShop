using System.Collections.Generic;
using WebShopNetCore2.Models.Data;
using WebShopNetCore2.Models.Entities;
using WebShopNetCore2.Models.Interfaces;

namespace WebShopNetCore2.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        public IEnumerable<Category> Categories => appDbContext.Categories;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
