using EmpeekTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpeekTestTask.Controllers
{
    public class PathController : ApiController
    {
        public RealPath Get(string path, int dir)
        {
            return new RealPath().findPath(path, dir);
        }

    }
}
