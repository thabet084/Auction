using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Domain
{
    public class ItemBid:BaseEntity
    {
        /// <summary>
        /// Navigation property for bidder
        /// </summary>
        public virtual Bidder Bidder { get; set; }

        /// <summary>
        /// Foregin key for bidder
        /// </summary>
        public long BidderId { get; set; }

        /// <summary>
        /// Navigation property for item
        /// </summary>
        public virtual Item Item { get; set; }

        /// <summary>
        /// Foregin key for item
        /// </summary>
        public long ItemId { get; set; }

        /// <summary>
        /// Bid value set by bidder
        /// </summary>
        public decimal Bid { get; set; }
    }
}
