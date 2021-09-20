using Application.Common.Mappings;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class ClientsDto : IMapFrom<Clients>
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Clients, ClientsDto>(MemberList.Destination);
            profile.CreateMap<ClientsDto, Clients>();
        }
    }
}
