using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Domain
{
    /// <summary>
    /// Bidder/participant
    /// </summary>
    public class Bidder:BaseEntity
    {
        /// <summary>
        /// Full name
        /// </summary>
        public string FullName { get; set; }
    }
}
