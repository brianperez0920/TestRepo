using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using MediatR;

namespace Application.Queries.Clients
{
    public class GetClientsQuery : IRequest<List<ClientsDto>>
    {
    }

    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientsDto>>
    {

        private readonly IClientsDAO _clientsDao;
        //private readonly IMapper mapper;

        public GetClientsQueryHandler(IClientsDAO clientsDao)
        {
            this._clientsDao = clientsDao;           
        }

        public async Task<List<ClientsDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Domain.Clients> results = await _clientsDao.GetTotalClientsResult();
                MappingHelperSubstitute mapper = new MappingHelperSubstitute();
                return mapper.MapClients(results);

            }catch(Exception ex)
            {
                var message = ex.Message;
                throw ex;
            }
        }
    }
}
