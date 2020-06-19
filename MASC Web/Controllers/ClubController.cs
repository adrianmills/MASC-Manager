using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic.DataRetrival.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASC_Web.Controllers
{
    public class ClubController : Controller
    {
        IClubData _clubData;


        public ClubController(IClubData clubData)
        {
            _clubData = clubData;
        }
        // GET: ClubController
        public ActionResult Index()
        {

            return PartialView("_list",_clubData.Clubs);
        }

        // GET: ClubController/Details/5
        public ActionResult Details(long id)
        {
            return PartialView("_detail",_clubData.Find(id,false));
        }

        // GET: ClubController/Create
        public ActionResult Create()
        {
            return PartialView("_create");
        }

        // POST: ClubController/Create
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

        // GET: ClubController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClubController/Edit/5
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

        // GET: ClubController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClubController/Delete/5
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
