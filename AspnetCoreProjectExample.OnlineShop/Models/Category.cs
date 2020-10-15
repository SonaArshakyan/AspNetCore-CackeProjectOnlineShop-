using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreProjectExample.OnlineShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Pie> Pies { get; set; }
    }
}