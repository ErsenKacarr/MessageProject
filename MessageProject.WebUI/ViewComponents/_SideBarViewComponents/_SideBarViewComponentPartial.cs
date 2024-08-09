using MessageProject.EntityLayer.Concrete;
using MessageProject.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessageProject.WebUI.ViewComponents._SideBarViewComponents
{
    public class _SideBarViewComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _SideBarViewComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            CurrentUserViewModel model = new CurrentUserViewModel()
            {
                Name = user.Name,
                ImageUrl = user.ImageUrl,
                Surname = user.Surname,
            };
            return View(model);
        }
    }
}
