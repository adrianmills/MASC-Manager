using Business_Logic.DataRetrival.Interface;
using Business_Logic.View_Model;
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
        public IActionResult Index()
        {
            var clubs = _clubData.Clubs;
            return PartialView("_list", clubs);
        }


        // GET: SyallabusController/Details/5
        public IActionResult  Details(long id)
        {
            var club = _clubData.Detail(id);
            return PartialView("_detail", club);
        }

        // GET: SyallabusController/Create
        public IActionResult Create()
        {
            return PartialView("_create");
        }

        // POST: SyallabusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ClubViewModel clubToCreate)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _clubData.Add(clubToCreate);
                  return  RedirectToAction("Index");
                }
                else
                {
                    return PartialView("_create",clubToCreate);
                }
            }
            catch
            {
                return PartialView("_create",clubToCreate);
            }
        }

        // GET: SyallabusController/Edit/5
        public IActionResult Edit(long id)
        {
            var club = _clubData.Detail(id);
            return PartialView("_edit", club);
        }

        // POST: SyallabusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [FromForm] ClubViewModel updatedClub)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clubData.Update(updatedClub);
                    return RedirectToAction("Index");
                }
                else
                {
                    return PartialView("_edit", updatedClub);
                }
            }
            catch
            {
                return PartialView("_edit", updatedClub);
            }
        }

        // GET: SyallabusController/Delete/5
        public IActionResult Delete(long id)
        {
            _clubData.Delete(id);
            return RedirectToAction("Index");
        }

    

    }
}
