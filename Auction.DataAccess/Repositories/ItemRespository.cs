using Auction.Domain;
using Auction.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DataAccess.Repositories
{
    public class ItemRespository : IItemRespository
    {
        private readonly AuctionDBContext _context;
        public ItemRespository(AuctionDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task Add(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public async Task<List<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }
    }
}
