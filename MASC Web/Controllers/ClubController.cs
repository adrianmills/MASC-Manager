using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic.DataRetrival.Interface;
using Business_Logic.DTO.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Logic.Session;
using Business_Logic.DTO;
using Business_Logic.DataRetrival;

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
            HttpContext.Session.Set("clubs", _clubData.Clubs);
            HttpContext.Session.Set("deletedclubs" , new List<IClubDTO>());
            var clubs = _clubData.Clubs;
            return PartialView("_list",clubs);
        }


        public void AddClub(string clubname)
        {
            var clubs = HttpContext.Session.Get<List<ClubDTO>>("clubs");

            var club = new ClubDTO { ClubName = clubname };

            clubs.Add(club);

            HttpContext.Session.Set("clubs",clubs);

        }

        public void UpdateClub(long id, string clubname)
        {
            var clubs = HttpContext.Session.Get<List<ClubDTO>>("clubs");

            var club = clubs.Where(c => c.ClubID == id).FirstOrDefault();

            club.ClubName = clubname;

            HttpContext.Session.Set("clubs", clubs);
        }

        public void DeleteClub(long id)
        {
            var clubs = HttpContext.Session.Get<List<ClubDTO>>("clubs");
            var deletedclubs = HttpContext.Session.Get<List<ClubDTO>>("deletedclubs");

            var club = clubs.Where(c => c.ID == id).FirstOrDefault();

            clubs.Remove(club);
            deletedclubs.Add(club);
            HttpContext.Session.Set("clubs", clubs);
            HttpContext.Session.Set("deletedclubs", deletedclubs);
        }

        public void SaveChanges()
        {
            var dataItems = new ClubDataItems();

            dataItems.Clubs = HttpContext.Session.Get<List<ClubDTO>>("clubs");
            dataItems.DeletedClubs = HttpContext.Session.Get<List<ClubDTO>>("deletedclubs");

            _clubData.ProccessClubs(dataItems);
        }
    }
}
