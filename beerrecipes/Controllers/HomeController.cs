using beerrecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace beerrecipes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Grains()
        {
            //get stuff
            var items = await DocumentDBRepository<Grain>.GetItemsAsync( x => x != null);
            return View(items);
        }
    }
}
