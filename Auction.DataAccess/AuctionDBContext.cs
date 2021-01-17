using Auction.Domain;
using Auction.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;


namespace Auction.DataAccess
{
    public class AuctionDBContext:DbContext
    {
        public AuctionDBContext(DbContextOptions  options) : base(options)
        {

        }

        /// <summary>
        /// Items
        /// </summary>
        public virtual DbSet<Item> Items { get; set; }

        /// <summary>
        /// Bidders
        /// </summary>
        public virtual DbSet<Bidder> Bidders { get; set; }

        /// <summary>
        /// Item bids
        /// </summary>
        public virtual DbSet<ItemBid> ItemBids { get; set; }

        /// <summary>
        /// Exception Logs
        /// </summary>
        public virtual DbSet<ExceptionLog> ExceptionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        
    }
}
