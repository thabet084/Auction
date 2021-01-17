using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Auction.Models;
using Auction.Services.ViewModels;
using Auction.Services.Interfaces;

namespace Auction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService _itemService;
        private readonly IErrorService _errorService;

        public HomeController(ILogger<HomeController> logger, IItemService itemService, IErrorService errorService)
        {
            _logger = logger;
            _itemService = itemService;
            _errorService = errorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="itemViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddItem(ItemViewModel itemViewModel)
        {
            try
            {
              

                await _itemService.Add(itemViewModel);
                var items = await _itemService.GetAll();
                return PartialView("~/Views/Shared/_Items.cshtml", items);
            }
            catch (Exception ex)
            {
                _errorService.SaveLog(Request.Path, itemViewModel, ex);
                throw ex;
            }

        }
    }
}
