using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MVCStartApp.Repositories;

namespace MVCStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogRepository _repo;

        public LogsController(ILogRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetLogs();
            return View(logs);
        }
    }
}
