using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models.DB;
using MVCStartApp.Repositories;
using System.Threading.Tasks;

namespace MVCStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _repo.AddUser(newUser);
            return View(newUser);
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }
    }
}
