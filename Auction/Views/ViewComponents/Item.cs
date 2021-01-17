using Auction.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Frontend.Views.ViewComponents
{
    public class Item : ViewComponent
    {
        IItemService  _itemService;
        public Item(IItemService itemService)
        {
            _itemService = itemService;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _itemService.GetAll();

            return View(items);
        }
    }
}
