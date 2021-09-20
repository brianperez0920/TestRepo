using Application.Common.Mappings;
using AutoMapper;
using Domain;

namespace Application.Dtos
{
    public class ApplicationsDto : IMapFrom<Applications>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public double AnnualIncome { get; set; }
        public double MonthlyDebt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Applications, ApplicationsDto>();
            profile.CreateMap<ApplicationsDto, Applications>();
        }
    }
}
