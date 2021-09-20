using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Clients
{
    public class GetNumberOfClientsWithAppsQuery : IRequest<int>
    {
    }

    public class GetNumberOfClientsWithAppsQueryHandler : IRequestHandler<GetNumberOfClientsWithAppsQuery, int>
    {
        private readonly IClientsDAO _clientsDao;

        public GetNumberOfClientsWithAppsQueryHandler(IClientsDAO clientsDao)
        {
            this._clientsDao = clientsDao;
        }
        public async Task<int> Handle(GetNumberOfClientsWithAppsQuery request, CancellationToken token)
        {
            try
            {
               return await _clientsDao.GetDistinctClientsWithApplication();                              
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw ex;
            }
        }
    }
}
