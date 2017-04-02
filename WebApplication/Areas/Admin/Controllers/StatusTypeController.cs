using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Core.Domains.StatusType;
using WebApplication.Data;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("[controller]")]
    public class StatusTypeController : Controller
    {
      private readonly IStatusTypeRepository _statusTypeRepository;

        public StatusTypeController(IStatusTypeRepository statusTypeRepository)
        {
            _statusTypeRepository = statusTypeRepository;
        }
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            var item = await _statusTypeRepository.FindAll();

            return View(item);
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(StatusType model)
        {
            if (ModelState.IsValid)
            {
                _statusTypeRepository.Save(model);
            }
            else
            {
                return View(model);
            };

            return RedirectToAction("Index");
        }
        [Route("[action]")]
        public async Task<IActionResult> Details(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var queryresult = await _statusTypeRepository.Get(id);

            if (queryresult == null)
            {
                return NotFound();
            }

            return View(queryresult);
        }
        [Route("[action]")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var queryresult = await _statusTypeRepository.Get(id);

            if (queryresult == null)
            {
                return NotFound();
            }

            return View(queryresult);
        }
        [Route("[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StatusType model)
        {

            if (ModelState.IsValid)
            {


                await _statusTypeRepository.Update(model);

                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("[action]")]
        public async Task<IActionResult> Delete(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var queryresult = await _statusTypeRepository.Get(id);

            if (queryresult == null)
            {
                return NotFound();
            }

            return View(queryresult);
        }

        [Route("[action]")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var item = await _statusTypeRepository.Get(id);
            await _statusTypeRepository.Delete(item);

            return RedirectToAction("Index");
        }


    }
}
