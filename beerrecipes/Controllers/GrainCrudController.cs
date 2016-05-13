using beerrecipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace beerrecipes.Controllers
{
    public class GrainCrudController : Controller
    {
        // GET: GrainCrud
        public async Task<ActionResult> Index()
        {
            var items = await DocumentDBRepository<Grain>.GetItemsAsync(x => x != null);
            return View(items);
        }

        // GET: GrainCrud/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var item = await DocumentDBRepository<Grain>.GetItemsAsync(x => x.id == id);
            return View(item.First());
        }

        // GET: GrainCrud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrainCrud/Create
        [HttpPost]
        public async Task<ActionResult> Create(Grain grain)
        {
            try
            {
                // TODO: Add insert logic here
                var item = await DocumentDBRepository<Grain>.CreateItemAsync(grain);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GrainCrud/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var item = await DocumentDBRepository<Grain>.GetItemsAsync(x => x.id == id);
            return View(item.First());
        }

        // POST: GrainCrud/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(string id, Grain grain)
        {
            try
            {
                var doc = await DocumentDBRepository<Grain>.ReplaceItemAsync(id, grain);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            var item = await DocumentDBRepository<Grain>.GetItemsAsync(x => x.id == id);
            return View(item.First());
        }

        // POST: GrainCrud/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection form)
        {
            try
            {
                var success = DocumentDBRepository<Grain>.DeleteItemAsyn(id);
                // TODO: Add toast message here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
