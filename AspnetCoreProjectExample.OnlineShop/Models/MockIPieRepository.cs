using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreProjectExample.OnlineShop.Models
{
    public class MockIPieRepository : IPieRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockICategoryRepository();
        public IEnumerable<Pie> AllPies =>
            new List<Pie>
            {
                new Pie{PieId = 1 , Name = "StrawberyPie" , Prices = 15 , ShortDescription= "Lorem Ipsum" ,LongDescription= "",CategoryId=1 , Category = _categoryRepository.AllCategories.FirstOrDefault( p => p.CategoryId == 1) },
                new Pie{PieId = 2 , Name = "StrawberyPie" , Prices = 15 , ShortDescription= "Lorem Ipsum" ,LongDescription= "",CategoryId=2 ,
                Category = _categoryRepository.AllCategories.FirstOrDefault( p => p.CategoryId == 1)},
                new Pie{PieId = 3 , Name = "StrawberyPie" , Prices = 15 , ShortDescription= "Lorem Ipsum" ,LongDescription= "",CategoryId=3,
                Category = _categoryRepository.AllCategories.FirstOrDefault( p => p.CategoryId == 1)}
            };

        public IEnumerable<Pie> PiesOfWeek { get; }
        public Pie GetPieById(int pieId)
        {
            return AllPies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
