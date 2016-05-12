using beerrecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace beerrecipes.Controllers
{
    public class GrainsController : ApiController
    {
        List<Grain> grains = new List<Grain>
            {
                new Grain { id = "1", name = "Amber Malt", lovibond = "35°", specificGravity = "1.032", description = "Roasted malt used in British milds, old ales, brown ales, nut brown ales." },
                new Grain { id = "2", name = "Brown Malt", lovibond = "65°", specificGravity = "1.032", description = "Imparts a dry, biscuit flavor. Use in porters, brown, nut brown and Belgian ales." },
                new Grain { id = "3", name = "Maris Otter Pale Malt", lovibond = "3°", specificGravity = "1.038", description = "Premium base malt for any beer. Good for pale ales."},
                new Grain { id = "4", name = "Pale Ale", lovibond = "2.2°", specificGravity = "1.038", description = "Moderate malt flavor. Used to produce traditional English and Scottish style ales."},
                new Grain { id = "5", name = "Lager Malt", lovibond = "1.6°", specificGravity = "1.038", description = "Used to make light colored and flavored lagers."}
            };

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, grains);
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
            var target = grains.First(x => x.id == request.id);

            if (target == null)
            {
                response = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to find Id: " + request.id);
            }
            else
            {
                target.description = request.description;
                target.lovibond = request.lovibond;
                target.name = request.name;
                target.specificGravity = request.specificGravity;

                response = Request.CreateResponse<Grain>(HttpStatusCode.OK, target);
            }
            return response;
        }
    }
}
