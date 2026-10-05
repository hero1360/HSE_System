using Microsoft.AspNetCore.Mvc;
using HSE.Web.Services;
using HSE.Web.Domain.Entities;

namespace HSE.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHseService _service;
        public HomeController(IHseService service) { _service = service; }
        public async Task<IActionResult> Index() => View(await _service.GetAllIncidentsAsync());
    }

    public class IncidentController : Controller
    {
        private readonly IHseService _service;
        public IncidentController(IHseService service) { _service = service; }

        public async Task<IActionResult> Index() => View(await _service.GetAllIncidentsAsync());
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Incident incident)
        {
            await _service.CreateIncidentAsync(incident);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var inc = await _service.GetIncidentByIdAsync(id);
            return inc == null ? NotFound() : View(inc);
        }

        [HttpPost]
        public async Task<IActionResult> AddInvestigation(IncidentInvestigation inv)
        {
            await _service.AddInvestigationAsync(inv);
            return RedirectToAction(nameof(Details), new { id = inv.IncidentId });
        }

        [HttpPost]
        public async Task<IActionResult> AddCorrectiveAction(CorrectiveAction ca)
        {
            await _service.AddCorrectiveActionAsync(ca);
            return RedirectToAction(nameof(Details), new { id = ca.IncidentId });
        }
    }
}
