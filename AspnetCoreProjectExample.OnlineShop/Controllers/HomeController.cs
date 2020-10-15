using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreProjectExample.OnlineShop.Models;
using AspnetCoreProjectExample.OnlineShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreProjectExample.OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public HomeController( IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = _pieRepository.PiesOfWeek
            };
            return View(homeViewModel);
        }
    }
}
