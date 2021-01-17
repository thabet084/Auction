using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Auction.Domain
{
    /// <summary>
    /// Base Entity Structure for all system entities
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Record's Primary Key
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// creation date time
        /// </summary>
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
       
    }
}
