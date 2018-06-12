using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopTutorial.Data.Models;

namespace WebShopTutorial.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
