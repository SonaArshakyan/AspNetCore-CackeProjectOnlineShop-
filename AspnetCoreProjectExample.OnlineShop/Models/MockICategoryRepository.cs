using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreProjectExample.OnlineShop.Models
{
    public class MockICategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{ CategoryId = 1 , CategoryName="Fruit pies", Description="All-fruity  pies"   },
                new Category{ CategoryId = 2 , CategoryName="Cheese cackes", Description="Chessy all the way "   },
                new Category{ CategoryId = 3 , CategoryName="Seadonal pies", Description="Get in the mood for a seasonal pie" }
            };
    }
}
