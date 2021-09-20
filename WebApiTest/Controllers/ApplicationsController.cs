using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries.Applications;
using Application.Queries.Credits;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTest.Helpers;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationsController : ApiController
    {
        [HttpGet]
        public async Task<JsonResponseApplicationsModel> Get()
        {
            try
            {
                var applications = await Mediator.Send(new GetApplicationsQuery());
                var credits = await Mediator.Send(new GetCreditsQuery());

                BuildJsonResponseHelper jsonHelper = new BuildJsonResponseHelper();
                return jsonHelper.BuildApplicationJsonResponse(applications, credits);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
