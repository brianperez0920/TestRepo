﻿using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TechTime.Inventory.Application.Common.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;            

        public RequestPerformanceBehaviour(
        )
        {
            _timer = new Stopwatch();
        
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                  
            }

            return response;
        }
    }
}
