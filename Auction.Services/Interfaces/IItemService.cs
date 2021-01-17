using Auction.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Services.Interfaces
{
    public interface IItemService
    {
        /// <summary>
        /// Add item 
        /// </summary>
        /// <param name="itemViewModel"></param>
        /// <returns></returns>
        Task Add(ItemViewModel itemViewModel);

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        Task<List<ItemViewModel>> GetAll();
    }
}
