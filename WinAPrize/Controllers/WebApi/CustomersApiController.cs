using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WinAPrize.Controllers.WebApi
{
    using WinAPrize.API.Interfaces;
    using WinAPrize.Models;

    public class CustomersApiController : ApiController
    {
        private readonly IApplicationManager applicationManager;

        //Ninject Dependency Injection
        public CustomersApiController(IApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
        }

        [HttpPost]
        [Route("api/CustomersApi")]
        public HttpResponseMessage Post([FromBody] Customer customer)
        {
            try
            {
                var found =
                    this.applicationManager.CustomerManager.Get<Customer>()
                        .FirstOrDefault(
                            x =>
                                x.FirstName.ToLower() == customer.FirstName.ToLower()
                                && x.LastName.ToLower() == customer.LastName.ToLower());

                if (found == null)
                {
                    this.applicationManager.CustomerManager.Add(customer);
                    this.applicationManager.CustomerManager.Save();

                    return this.Request.CreateResponse(HttpStatusCode.Accepted, customer.CustomerId);
                }

                return this.Request.CreateResponse(HttpStatusCode.Accepted, found.CustomerId);

            }
            catch (Exception ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
