using MessageProject.BusinessLayer.Concrete;
using MessageProject.DataAccessLayer.Context;
using MessageProject.DataAccessLayer.EntityFramework;
using MessageProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessageProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        private readonly UserManager<AppUser> _userManager;

        public ContactController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var values = _contactManager.GetList();
            return View(values);
        }
        public async Task<IActionResult> Inbox(string m)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            m = values.Email;
            var messageList = _messageManager.GetListReceiverMessage(m);
            return View(messageList);
        }
        public IActionResult InboxMessageDetails(int id)
        {
           var messageList = _messageManager.TGetById(id);
           return View(messageList);
        }
        public async Task<IActionResult> Sendbox(string m)  
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            m = values.Email;
            var messageList = _messageManager.GetListSenderMessage(m);
            return View(messageList);
        }
        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message m)
        {
            return View();
        }
        public IActionResult SendboxMessageDetails(int id)
        {
            var messageList = _messageManager.TGetById(id);
            return View(messageList);
        }
        public IActionResult TrashMessageList()
        {
            var values = _messageManager.GetListDeleteMessage();
            return View(values);
        }
        public IActionResult TrashMessages(int id)
        {
            MessageContext _context = new MessageContext();
            var value = _context.Messages.Where(x => x.MessageID == id).FirstOrDefault();
            value.Status = false;
            _context.SaveChanges();
            return RedirectToAction("TrashMessageList");
        }
        public IActionResult TrashOutMessages(int id)
        {
            MessageContext _context = new MessageContext();
            var value = _context.Messages.Where(x => x.MessageID == id).FirstOrDefault();
            value.Status = true;
            _context.SaveChanges();
            return RedirectToAction("TrashMessageList");
        }

    }
}
