using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Contracts
{
    public interface IItemRespository
    {
        Task Add(Item item);

        Task<List<Item>> GetAll();
    }
}
