using Auction.Domain.Contracts;
using Auction.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auction.Services.Classes
{
    public class ErrorService: IErrorService
    {
        private readonly IErrorLogRepository _errorLogRepository;
        public ErrorService(IErrorLogRepository errorLogRepository)
        {
            _errorLogRepository = errorLogRepository;
        }
        /// <summary>
        /// Saving exception log
        /// </summary>
        /// <param name="executionPath">Method</param>
        /// <param name="param">Parameters used</param>
        /// <param name="exception">Exception details</param>

        public void SaveLog(string executionPath, object param, Exception exception)
        {
            _errorLogRepository.SaveLog(executionPath, param, exception);
        }
    }
}
