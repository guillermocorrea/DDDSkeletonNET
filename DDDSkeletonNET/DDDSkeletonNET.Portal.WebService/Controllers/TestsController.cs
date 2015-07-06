using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DDDSkeletonNET.Portal.WebService.Controllers
{
    [RoutePrefix("api/v1/tests")]
    public class TestsController : ApiController
    {
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new List<string>() { "hey" });
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok("hey");
        }
    }
}
