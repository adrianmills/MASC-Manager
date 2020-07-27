using Business_Logic.View_Model.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASC_Web.Controllers.Interface
{
    public interface IMascController<T> where T:IViewModelBase
    {
        IActionResult Create();
        IActionResult Create([FromForm] T recordToCreate);
        IActionResult Delete(long id);
        IActionResult Details(long id);
        IActionResult Edit(long id);
        IActionResult Edit(long id, [FromForm] T recordToUpdate);
        IActionResult Index();
    }
}
