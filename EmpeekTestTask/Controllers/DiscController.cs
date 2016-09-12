using EmpeekTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpeekTestTask.Controllers
{
    public class DiscController : ApiController
    {
        public IEnumerable<Disc> Get()
        {
            return new Disc().findAll();
        }
    }
}
