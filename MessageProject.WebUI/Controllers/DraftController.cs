﻿using MessageProject.BusinessLayer.Concrete;
using MessageProject.DataAccessLayer.Context;
using MessageProject.DataAccessLayer.EntityFramework;
using MessageProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessageProject.WebUI.Controllers
{
    public class DraftController : Controller
    {
        DraftManager draftManager = new DraftManager(new EfDraftDal());
        private readonly UserManager<AppUser> _userManager;

        public DraftController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult DraftMessageList()
        {
            var values = draftManager.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult DraftMessageSave()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> DraftMessageSave(Draft p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = DateTime.Now;
            p.SenderMail = mail;
            p.SenderName = name;
            p.Status = true;
            MessageContext c = new MessageContext();
            var usernamesurname = c.Users.Where(x => x.Email == p.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            draftManager.TInsert(p);
            return RedirectToAction("DraftMessageList");

        }
        public IActionResult DraftOut(int id)
        {
            draftManager.TDelete(id);
            return RedirectToAction("DraftMessageList");
        }
    }
}
