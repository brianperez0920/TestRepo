using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IClientsDAO
    {
        public Task<IEnumerable<Clients>> GetTotalClientsResult();
        public Task<int> GetDistinctClientsWithApplication();
    }
}
