using EventosTeste.Interfaces;
using EventosTeste.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventosTeste.Controllers
{
    public class LocaisController : Controller
    {
        private readonly ILocaisRepository _LocaisRepositories;

        public LocaisController(ILocaisRepository LocaisRepositories)
        {
            _LocaisRepositories = LocaisRepositories;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _LocaisRepositories.GetAll());
        }

        public async Task<IActionResult> Details(int id)
        {
            var local = await _LocaisRepositories.GetById(id);
            if (local == null) return NotFound();
            return View(local);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Local local)
        {
            if (!ModelState.IsValid) return View(local);

            await _LocaisRepositories.Add(local);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var local = await _LocaisRepositories.GetById(id);
            if (local == null) return NotFound();

            return View(local);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Local local)
        {
            if (!ModelState.IsValid) return View(local);

            await _LocaisRepositories.Update(local);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var local = await _LocaisRepositories.GetById(id);
            if (local == null) return NotFound();
            return View(local);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _LocaisRepositories.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
