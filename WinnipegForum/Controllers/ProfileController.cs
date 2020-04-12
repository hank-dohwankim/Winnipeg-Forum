using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WinnipegForum.Data;
using WinnipegForum.Data.Models;

namespace WinnipegForum.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IUpload _upload;

        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload upload)
        {
            _userManager = userManager;
            _userService = userService;
            _upload = upload;
        }

        public IActionResult Detail(string id)
        {
            return View();
        }
    }
}