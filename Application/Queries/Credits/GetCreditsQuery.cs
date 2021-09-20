using Application.Common.Interfaces;
using Application.Dtos;
using Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Credits
{
    public class GetCreditsQuery : IRequest<List<CreditsDto>>
    {
    }
    public class GetCreditsQueryHandler : IRequestHandler<GetCreditsQuery, List<CreditsDto>>
    {
        private readonly ICreditDAO _creditDAO;

        public GetCreditsQueryHandler(ICreditDAO creditDAO)
        {
            this._creditDAO = creditDAO;
        }

        public async Task<List<CreditsDto>> Handle(GetCreditsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Domain.Credits> results = await _creditDAO.GetTotalClientsResult();
                MappingHelperSubstitute mapper = new MappingHelperSubstitute();
                return mapper.MapCredits(results);

            }catch(Exception ex)
            {
                var message = ex.Message;
                throw ex;
            }
        }

    }
}
