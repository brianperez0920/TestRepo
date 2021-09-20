using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Queries.Clients;
using Application.Queries.Credits;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Helpers;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ApiController
    {
        [HttpGet]        
        public async Task<JsonResponseClientsModel> Get()
        {
            try
            {
                var clients = await Mediator.Send(new GetClientsQuery());
                var distinctClientsWithApps = await Mediator.Send(new GetNumberOfClientsWithAppsQuery());
                var credits = await Mediator.Send(new GetCreditsQuery());

                BuildJsonResponseHelper jsonHelper = new BuildJsonResponseHelper();
                return jsonHelper.BuildClientJsonResponse(clients, distinctClientsWithApps, credits);
               
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
