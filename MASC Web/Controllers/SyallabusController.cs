using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic.DataRetrival.Interface;
using Business_Logic.View_Model;
using MASC_Web.Controllers.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASC_Web.Controllers
{
    public class SyallabusController : Controller, IMascController<SyllabusViewModel>
    {
        ISyllabusData _data;
        public SyallabusController(ISyllabusData syllabusData)
        {
            _data = syllabusData;
        }

        public IActionResult Create()
        {
            return PartialView("_create");
        }

        public IActionResult Create([FromForm] SyllabusViewModel recordToCreate)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _data.Add(recordToCreate);
                    return RedirectToAction("Index");
                }
                else
                {
                    return PartialView("_create", recordToCreate);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("","Sorry an error has occured. It has been logged and the relevent people informed");
                return PartialView("_create", recordToCreate);
            }
        }

        public IActionResult Delete(long id)
        {
            _data.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Details(long id)
        {
            var syllabus = _data.Detail(id);
            return PartialView("_detail", syllabus);

        }

        public IActionResult Edit(long id)
        {
            var syllabus = _data.Detail(id);
            return PartialView("_edit", syllabus);
        }

        public IActionResult Edit(long id, [FromForm] SyllabusViewModel recordToUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _data.Update(recordToUpdate);
                    return RedirectToAction("Index");
                }
                else
                {
                    return PartialView("_edit", recordToUpdate);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Sorry an error has occured. It has been logged and the relevent people informed");
                return PartialView("_edit", recordToUpdate);
            }
        }

        public IActionResult Index()
        {
            var syllabi = _data.Syllabi;

            return PartialView("_list", syllabi);
        }
    }
}
