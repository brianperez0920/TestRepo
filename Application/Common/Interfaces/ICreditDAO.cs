using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICreditDAO
    {
        public Task<IEnumerable<Credits>> GetTotalClientsResult();
    }
}
