using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreProjectExample.OnlineShop.Models
{
    public class PieRepository : IPieRepository
    { private readonly AppDBContext _appDBContext;
        public PieRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDBContext.Pies.Include(c => c.Category);
            }
        }
        public IEnumerable<Pie> PiesOfWeek
        {
            get
            {
                return _appDBContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfWeek==true);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _appDBContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
