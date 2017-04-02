using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Core.Domains.MessageTemplate;
using WebApplication.Infrastructure.Interface.Repository;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin")]
    
    public class MessageTemplateController : Controller
    {
        public MessageTemplateController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        protected readonly IMessageRepository _messageRepository;
        [Route("[action]")]
        public async Task<IActionResult> Index()
        {
            var item = await _messageRepository.FindAll();

            return View(item);
        }
        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult Create(MessageTemplate model)
        {
            if (ModelState.IsValid)
            {
                MessageTemplate item = new MessageTemplate
                {
                    MessageTemplateTypeID = model.MessageTemplateTypeID,

                    Subject = model.Subject,
                    Body = Request.Form["editor1"].ToString(),
                    MailFrom = model.MailFrom
                };

                _messageRepository.Save(item);
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

            var queryresult = await _messageRepository.Get(id);

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
            var queryresult = await _messageRepository.Get(id);

            if (queryresult == null)
            {
                return NotFound();
            }

            return View(queryresult);
        }
        [Route("[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MessageTemplate model)
        {

            if (ModelState.IsValid)
            {
                MessageTemplate item = new MessageTemplate
                {
                    MessageTemplateTypeID = model.MessageTemplateTypeID,
                    Id = model.Id,
                    Subject = model.Subject,
                    Body = Request.Form["editor1"].ToString(),
                    MailFrom = model.MailFrom
                };


                await _messageRepository.UpdateMsg(item);

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
            var queryresult = await _messageRepository.Get(id);

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
            var item = await _messageRepository.Get(id);
            await _messageRepository.Delete(item);

            return RedirectToAction("Index");
        }

    }
}
