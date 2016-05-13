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
            return View(item);
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
                await DocumentDBRepository<Grain>.CreateItemAsync(grain);
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
            return View(item);
        }

        // POST: GrainCrud/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GrainCrud/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: GrainCrud/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
