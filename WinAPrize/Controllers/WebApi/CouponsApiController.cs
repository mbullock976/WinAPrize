using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WinAPrize.Controllers.WebApi
{
    using System.Threading.Tasks;

    using Microsoft.Ajax.Utilities;

    using WinAPrize.API.Interfaces;
    using WinAPrize.Models;

    public class CouponsApiController : ApiController
    {
        private readonly IApplicationManager applicationManager;

        //Dependency Injection - using Ninject - resolves the resuable WinAPrize.API.IApplicationManager
        //implemented in WinAPrize.Platform 
        //using WinAPrize.DependencyResolver to resolve
        //Therefore API acts like a plugin to the website
        public CouponsApiController(IApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
        }

        [HttpGet]
        [Route("api/CouponsApi/{couponCode?}")]
        public async Task<HttpResponseMessage> Get([FromUri] string couponCode)
        {
            
            bool isPrimeNumber = await this.applicationManager.IsCouponPrimeNumberAsync(couponCode);
            
            if (isPrimeNumber)
            {
                return await Task<HttpResponseMessage>.Factory.StartNew(() =>
                {
                    return Request.CreateResponse(HttpStatusCode.OK, true);
                });

            }
            else
            {
                return await Task<HttpResponseMessage>.Factory.StartNew(() =>
                {
                    return Request.CreateResponse(HttpStatusCode.OK, false);
                });
            }            
        }

        [HttpPost]
        [Route("api/CouponsApi")]
        public HttpResponseMessage Post([FromBody] Coupon coupon)
        {
            try
            {
                var found =
                    this.applicationManager.CustomerManager.Get<Coupon>()
                        .FirstOrDefault(x => x.Code.ToLower() == coupon.Code.ToLower());

                if (found == null)
                {
                    this.applicationManager.CustomerManager.Add(coupon);
                    this.applicationManager.CustomerManager.Save();

                    return this.Request.CreateResponse(HttpStatusCode.Accepted, coupon.CouponId);
                }

                return this.Request.CreateResponse(HttpStatusCode.Accepted, found.CouponId);

            }
            catch (Exception ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
