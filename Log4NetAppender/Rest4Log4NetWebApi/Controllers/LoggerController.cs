﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Rest4Log4NetModels;

namespace Rest4Log4NetWebApi.Controllers
{
    public class LoggerController : ApiController
    {
        // GET: api/Logger
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Logger/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Logger
        public void Post([FromBody]LogMessage value)
        {
            var tmp = value;
        }

        // PUT: api/Logger/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Logger/5
        public void Delete(int id)
        {
        }
    }
}
