using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Repositories;

namespace mvc.Controllers
{
    public class ajaxuserController : Controller
    {
        private readonly IUserRepositories _userRepositories;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ajaxuserController(IUserRepositories userRepositories, IHttpContextAccessor httpContextAccessor)
        {
            _userRepositories = userRepositories;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] tblUser user)
        {
            _userRepositories.Login(user);

            var role = HttpContext.Session.GetString("role");
            // if(role == "Admin")
            // {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "mvcajax") });
            // }
            // else{
                // return Json(new { success = true, redirectUrl = Url.Action("Index2", "mvcajax") });
            // }
            
           
            // int rowCount = _userRepositories.Login(user);

            // if (rowCount == 1)
            // {
            //     var role = HttpContext.Session.GetString("role");

            //     if (role == "Admin")
            //     {
            //         // Redirect to Index action for admin
            //         return Json(new { success = true, redirectUrl = Url.Action("Index", "MvcAjax") });
            //     }
            //     else
            //     {
            //         // Redirect to Index action for non-admin users
            //         return Json(new { success = true, redirectUrl = Url.Action("Index2", "MvcAjax") });
            //     }
            // }
            // else
            // {
            //     return Json(new { success = true, redirectUrl = Url.Action("Index2", "MvcAjax") });
            // }
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromBody] tblUser user)
        {
            user.c_role = "User";
            _userRepositories.Register(user);
            return Json(new { message = "Registration successful" });
        }

        [HttpGet]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}