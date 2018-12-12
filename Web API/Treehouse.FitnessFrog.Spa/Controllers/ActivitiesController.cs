using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Data;

namespace Treehouse.FitnessFrog.Spa.Controllers
{
    public class ActivitiesController : ApiController
    {
        private ActivitiesRepository _activitiesRepository = null;

        public ActivitiesController(ActivitiesRepository activitiesRepository)
        {
            _activitiesRepository = activitiesRepository;
        }

        // return 200 for collection
        public IHttpActionResult Get()
        {
            return Ok(_activitiesRepository.GetList());
        }

        // return 404 if not found
        // return 200 if single record found
        public IHttpActionResult Get(int id)
        {
            var result = _activitiesRepository.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
