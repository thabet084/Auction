using Auction.Domain.Common;
using Auction.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auction.DataAccess.Repositories
{
    /// <summary>
    /// Error Log Repository
    /// </summary>
    public class ErrorLogRepository : IErrorLogRepository
    {
        private readonly AuctionDBContext _context;

        /// <summary>
        /// Constructor for ErrorLogRepository
        /// </summary>
        /// <param name="context"></param>
        public ErrorLogRepository(AuctionDBContext context) 
        {
            _context = context;
        }

        /// <summary>
        /// Saving exception log
        /// </summary>
        /// <param name="executionPath">Method</param>
        /// <param name="param">Parameters used</param>
        /// <param name="exception">Exception details</param>

        public void SaveLog(string executionPath, object param, Exception exception)
        {
            try
            {
                ClearTrackedEntities();
                var log = new ExceptionLog
                {
                    Method = executionPath,
                    Exception = SerializeException(exception),

                    Data = SerializeObject(param)


                };
                _context.Add(log);
                _context.SaveChanges();

            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        /// Serialize exception object
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private string SerializeException(Exception e)
        {
            try
            {
                return JsonConvert.SerializeObject(e,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    });
            }
            catch (Exception)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Serialze object to string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string SerializeObject(object data)
        {
            try
            {
                return JsonConvert.SerializeObject(data,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    });
            }
            catch (Exception)
            {
                return data.ToString();
            }
        }

        /// <summary>
        /// Clear entities 
        /// </summary>
        private void ClearTrackedEntities()
        {
            //Clear Tracked Entities to avoid re-throwing db related exceptions
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
