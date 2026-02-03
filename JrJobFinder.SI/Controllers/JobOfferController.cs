using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JrJobFinder.BL;

namespace JrJobFinder.SI.Controllers
{
    public class JobOfferController : Controller
    {
        private readonly IJobOfferBL OfferManager;
        public JobOfferController(IJobOfferBL offerManager)
        {
            OfferManager = offerManager;
        }
        [HttpGet("/api/JobOffers")]
        public IQueryable GetAllJobOffers()
        {
            return OfferManager.GetAllJobOffers();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
