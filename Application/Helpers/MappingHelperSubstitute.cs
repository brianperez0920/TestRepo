using Application.Dtos;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Helpers
{
    public class MappingHelperSubstitute
    {
        public List<ClientsDto> MapClients(IEnumerable<Clients> clients)
        {
            List<ClientsDto> clientDtoList = new List<ClientsDto>();
            foreach (var client in clients)
            {
                ClientsDto clientDto = new ClientsDto();

                clientDto.id = client.id;
                clientDto.first_name = client.first_name;
                clientDto.last_name = client.last_name;
                clientDto.email = client.email;

                clientDtoList.Add(clientDto);
            }
            return clientDtoList;
        }
        public List<CreditsDto> MapCredits(IEnumerable<Credits> credits)
        {
            List<CreditsDto> creditsDtoList = new List<CreditsDto>();
            foreach(var credit in credits)
            {
                CreditsDto creditDto = new CreditsDto();
                creditDto.Id = credit.Id;
                creditDto.ClientId = credit.ClientId;
                creditDto.CreditScore = credit.CreditScore;

                creditsDtoList.Add(creditDto);
            }
            return creditsDtoList;
        }
        public List<ApplicationsDto> MapApplications(IEnumerable<Applications> applications)
        {
            List<ApplicationsDto> applicationDtoList = new List<ApplicationsDto>();
            foreach(var app in applications)
            {
                ApplicationsDto applicationDto = new ApplicationsDto();
                applicationDto.Id = app.Id;
                applicationDto.ClientId = app.ClientId;
                applicationDto.AnnualIncome = app.AnnualIncome;
                applicationDto.MonthlyDebt = app.MonthlyDebt;

                applicationDtoList.Add(applicationDto);
            }
            return applicationDtoList;
        }
    }
}
