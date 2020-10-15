using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreProjectExample.OnlineShop.Models;

namespace AspnetCoreProjectExample.OnlineShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRespository;
        private readonly ICategoryRepository _categoryRepository;
        public PieController(IPieRepository pieRespository , ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _pieRespository = pieRespository;
        }
        //public ViewResult List()
        //{
        //    PiesListViewModel piesListViewModel = new PiesListViewModel();
        //    piesListViewModel.Pies = _pieRespository.AllPies;
        //    piesListViewModel.CurrentCategory = "Cheese cackes";
        //    return View(piesListViewModel);
        //}
        public ViewResult List(string category )
        {
            IEnumerable<Pie> pies;
            string currentCategry;
            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRespository.AllPies.OrderBy(p => p.PieId);
                currentCategry = "All pies";
            }
            else
            {
                pies = _pieRespository.AllPies.Where(p => p.Category.CategoryName == category).OrderBy(p => p.PieId);
                currentCategry = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new PiesListViewModel
            {
                 CurrentCategory = currentCategry,
                 Pies = pies
            });
        }
        public IActionResult Detail(int id)
        {
            var pie = _pieRespository.GetPieById(id);
            if (pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
