using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WinAPrize.Controllers.WebApi
{
    using WinAPrize.API.Interfaces;

    public class MarketingApiController : ApiController
    {
        private readonly IApplicationManager applicationManager;

        //Ninject Dependency Injection
        public MarketingApiController(IApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
        }

        [HttpGet]
        [Route("api/MarketingApi/")]
        public HttpResponseMessage Get()
        {
            return this.Request.CreateResponse(
                HttpStatusCode.Accepted, 
                this.applicationManager.MarketingManager.GetTotalWinnersLimit());
        }

        [HttpPost]
        [Route("api/MarketingApi/{totalLimit?}")]
        public void Post([FromUri]int? totalLimit)
        {
            if (totalLimit.HasValue)
            {
                this.applicationManager.MarketingManager.SetTotalWinnersLimit(totalLimit.Value);
            }
        }        
    }
}
