using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Auction.Domain
{
    /// <summary>
    /// Item info
    /// </summary>
    public class Item : BaseEntity
    {
        /// <summary>
        /// Item name
        /// </summary>
        /// 
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Starting sale price
        /// </summary>
        /// 
        [Required]
        public decimal StartingPrice { get; set; }

        /// <summary>
        /// Collection of Item bids
        /// </summary>
        public virtual ICollection<ItemBid> ItemBids {get;set;}
    }
}
