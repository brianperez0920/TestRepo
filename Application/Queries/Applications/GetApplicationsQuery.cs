using Application.Common.Interfaces;
using Application.Dtos;
using Application.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.Applications
{
    public class GetApplicationsQuery : IRequest<List<ApplicationsDto>>
    {
    }

    public class GetApplicationsQueryHandler : IRequestHandler<GetApplicationsQuery, List<ApplicationsDto>>
    {
        private readonly IApplicationsDAO _applicationsDAO;

        public GetApplicationsQueryHandler(IApplicationsDAO applicationsDAO)
        {
            this._applicationsDAO = applicationsDAO;
        }

        public async Task<List<ApplicationsDto>> Handle(GetApplicationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Domain.Applications> results = await _applicationsDAO.GetTotalApplicationsResult();
                MappingHelperSubstitute mapper = new MappingHelperSubstitute();
                return mapper.MapApplications(results);

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw ex;
            }
        }
    }
    
}
