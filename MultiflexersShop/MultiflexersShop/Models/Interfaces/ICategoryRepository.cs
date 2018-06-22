using MultiflexersShop.Models.Entities;
using System.Collections.Generic;

namespace MultiflexersShop.Models.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
