using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class JsonResponseClientsModel
    {
        public int TotalNumberOfClients { get; set; }
        public int NumberOfClientsWithAnApp { get; set; }
        public int NumberOfClientsMissingCreditData { get; set; }
        public double AverageCreditScore { get; set; }
    }
}
