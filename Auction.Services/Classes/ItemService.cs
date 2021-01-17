using Auction.Domain;
using Auction.Domain.Contracts;
using Auction.Services.Interfaces;
using Auction.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Services.Classes
{
    public class ItemService : IItemService
    {
        private readonly IItemRespository _itemRespository;
        private readonly IMapper _mapper;
        public ItemService(IItemRespository itemRespository, IMapper mapper)
        {
            _itemRespository = itemRespository;
            _mapper = mapper;
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="itemViewModel"></param>
        /// <returns></returns>
        public async Task Add(ItemViewModel itemViewModel)
        {
            var item = _mapper.Map<Item>(itemViewModel);
            await _itemRespository.Add(item);

        }

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public async Task<List<ItemViewModel>> GetAll()
        {
            var items= await _itemRespository.GetAll();
            return _mapper.Map<List<ItemViewModel>>(items);
        }
    }
}
