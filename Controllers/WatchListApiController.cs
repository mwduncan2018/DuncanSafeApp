using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DuncanSafeApp2024.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WatchListApiController : ControllerBase
    {
        // GET: WatchListApi/Get
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: WatchListApi/Get/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: WatchListApi/Post
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: WatchListApi/Put/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: WatchListApi/Delete/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}