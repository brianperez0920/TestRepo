using Application.Common.Mappings;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dtos
{
    public class CreditsDto : IMapFrom<Credits>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [MaxLength(3)]
        public int CreditScore { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Credits, CreditsDto>();
            profile.CreateMap<CreditsDto, Credits>();
        }
    }
}
