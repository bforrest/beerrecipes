using beerrecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace beerrecipes.Controllers
{
    public class GrainsController : ApiController
    {
        List<Grain> grains = new List<Grain>
            {
                new Grain { Id = 1, Name = "Amber Malt", Lovibond = "35°", SpecificGravity = "1.032", Description = "Roasted malt used in British milds, old ales, brown ales, nut brown ales." },
                new Grain { Id = 2, Name = "Brown Malt", Lovibond = "65°", SpecificGravity = "1.032", Description = "Imparts a dry, biscuit flavor. Use in porters, brown, nut brown and Belgian ales." },
                new Grain { Id = 3, Name = "Maris Otter Pale Malt", Lovibond = "3°", SpecificGravity = "1.038", Description = "Premium base malt for any beer. Good for pale ales."},
                new Grain { Id = 4, Name = "Pale Ale", Lovibond = "2.2°", SpecificGravity = "1.038", Description = "Moderate malt flavor. Used to produce traditional English and Scottish style ales."},
                new Grain { Id = 5, Name = "Lager Malt", Lovibond = "1.6°", SpecificGravity = "1.038", Description = "Used to make light colored and flavored lagers."}
            };

        public IEnumerable<Grain> Get()
        {
            return grains;
        }

        public HttpResponseMessage Post([FromBody]Grain request)
        {
            grains.Add(request);
            var response = Request.CreateResponse(HttpStatusCode.OK, request);
            return response;
        }

        public HttpResponseMessage Put([FromBody]Grain request)
        {
            HttpResponseMessage response = null;
            var target = grains.First(x => x.Id == request.Id);

            if (target == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to find Id: " + request.Id);
            }
            else
            {
                target.Description = request.Description;
                target.Lovibond = request.Lovibond;
                target.Name = request.Name;
                target.SpecificGravity = request.SpecificGravity;

                response = Request.CreateResponse<Grain>(HttpStatusCode.OK, target);
            }
            return response;
        }
    }
}
