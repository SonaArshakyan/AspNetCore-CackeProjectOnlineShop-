using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreProjectExample.OnlineShop.Models
{
  public  interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfWeek { get; }
        Pie GetPieById(int pieId);

    }
}
