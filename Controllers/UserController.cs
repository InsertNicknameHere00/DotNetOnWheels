using CarManagerAPI.Entities;
using CarManagerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensions.Msal;

namespace CarManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserRepository _repository;
        private readonly IHttpContextAccessor _session;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserController(UserRepository repository, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _session = httpContextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginUsers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginUsers(User user)
        {
            var tempUser = await _repository.GetUserByIdAsync(user.Id);
            var tempUsername = tempUser.Name;
            var tempPassword = tempUser.Password;
            if (user.Name.Equals(tempUsername) && user.Password.Equals(tempPassword))
            {
                var sessionTemp = _session.HttpContext.Session;
                sessionTemp.SetString("IsLoggedIn", "LoggedIn");

                return RedirectToAction("Index", "Home");
            }
            else
            {

                ModelState.AddModelError("", "Грешно потребителско име или парола!");
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            var sessionTemp = _session.HttpContext.Session;
            if (sessionTemp != null)
            {
                sessionTemp.Remove("IsLoggedIn");
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("LoginUsers", "Users");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync() {
        var userTemp = await _repository.GetAllUsersAsync();
            if (userTemp == null)
            {
                return Ok(userTemp);
            }
           return Index();
        }



    }
}
