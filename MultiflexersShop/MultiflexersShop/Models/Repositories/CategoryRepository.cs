using MultiflexersShop.Models.Data;
using MultiflexersShop.Models.Entities;
using MultiflexersShop.Models.Interfaces;
using System.Collections.Generic;

namespace MultiflexersShop.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Category> Categories => appDbContext.Categories;
    }
}