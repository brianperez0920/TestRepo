using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.Helpers
{
    public class BuildJsonResponseHelper
    {
        public JsonResponseClientsModel BuildClientJsonResponse(List<ClientsDto> clients, int distinctAppClients, List<CreditsDto> credits)
        {
            JsonResponseClientsModel jsonResponse = new JsonResponseClientsModel();
            jsonResponse.TotalNumberOfClients = clients.Count();
            jsonResponse.NumberOfClientsWithAnApp = distinctAppClients;
            jsonResponse.NumberOfClientsMissingCreditData = FindNumberOfClientsMissingCreditData(clients, credits);
            jsonResponse.AverageCreditScore = AverageCreditScore(credits);

            return jsonResponse;

        }

        public int FindNumberOfClientsMissingCreditData(List<ClientsDto> clients, List<CreditsDto> credits)
        {
            int counter = 0;

            foreach(var client in clients)
            {
                bool creditExists = credits.Any(x => x.ClientId == client.id);
                if (!creditExists)
                    counter++;
            }
            return counter;
        }
        public double AverageCreditScore(List<CreditsDto> credits)
        {
            int creditSum = 0;
            foreach(var credit in credits)
            {
                creditSum += credit.CreditScore;
            }
            return creditSum / credits.Count;
        }

        public JsonResponseApplicationsModel BuildApplicationJsonResponse(List<ApplicationsDto> applications, List<CreditsDto> credits)
        {
            JsonResponseApplicationsModel jsonResponse = new JsonResponseApplicationsModel();
            jsonResponse.TotalNumbersOfApps = applications.Count();
            jsonResponse.NumberOfQualifyingApps = NumberOfApplicationsThatQualify(applications, credits);

            return jsonResponse;

        }
        public int NumberOfApplicationsThatQualify(List<ApplicationsDto> applications, List<CreditsDto> credits)
        {
            int qualifiedApps = 0;
            foreach(var app in applications)
            {
                bool partialqualify = false;
                bool goodcredit = false;

                double monthlyIncome = app.AnnualIncome / 12;
                double qualifyingPercent = (app.MonthlyDebt / monthlyIncome) * 100;

                if (qualifyingPercent < 50)
                {
                    partialqualify = true;
                }
                var creditobj = credits.Where(x => x.ClientId == app.ClientId).FirstOrDefault();
                
                if(creditobj.CreditScore > 520)
                {
                    goodcredit = true;
                }
                if (partialqualify && goodcredit)
                    qualifiedApps++;
            }
            return qualifiedApps;
        }
    }
}
