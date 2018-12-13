using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Models;

namespace Treehouse.FitnessFrog.Spa.Controllers
{
    public class IntensitiesController : ApiController
    {
        public IHttpActionResult Get()
        {
            // my solution returns an array, but not the id and name
            // as required by the client app
            // return Ok(Enum.GetValues(typeof(Entry.IntensityLevel)));

            // actual solution
            var result = Enum.GetValues(typeof(Entry.IntensityLevel))
                // cast all Enum values as type Entry.IntensityLevel
                .Cast<Entry.IntensityLevel>()
                // project each value into our new form with ID and name
                .Select(il => new { id = (int)il, name = il.ToString() })
                .ToList();

            return Ok(result);
        }
    }
}
