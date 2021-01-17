using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Services.Interfaces
{
    public interface IErrorService
    {
        /// <summary>
        /// Saving exception log
        /// </summary>
        /// <param name="executionPath">Method</param>
        /// <param name="param">Parameters used</param>
        /// <param name="exception">Exception details</param>

         void SaveLog(string executionPath, object param, Exception exception);
    }
}
