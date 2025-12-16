using EventosTeste.Interfaces;
using EventosTeste.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventosTeste.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventosRepository _Eventosrepositories;
        private readonly ILocaisRepository _LocaisRepository;

        public EventosController(IEventosRepository Eventosrepositories, ILocaisRepository locaisRepository)
        {
            _Eventosrepositories = Eventosrepositories;
            _LocaisRepository = locaisRepository;
        }

        public async Task<IActionResult> Index()
        {
            var eventos = await _Eventosrepositories.GetAll();
            var locais = await _LocaisRepository.GetAll();

            foreach (var e in eventos)
            {
                e.NomeLocal = locais.FirstOrDefault(x => x.IdLocal == e.Local)?.Nome;
            }

            return View(eventos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var evento = await _Eventosrepositories.GetById(id);
            if (evento == null) return NotFound();
            return View(evento);
        }

        public async Task<IActionResult> Create()
        {
            var locais = await _LocaisRepository.GetAll();
            ViewBag.Locais = locais;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Locais = await _LocaisRepository.GetAll();
                return View(evento);
            }

            await _Eventosrepositories.Add(evento);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var evento = await _Eventosrepositories.GetById(id);
            if (evento == null) return NotFound();

            ViewBag.Locais = await _LocaisRepository.GetAll();
            return View(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Locais = await _LocaisRepository.GetAll();
                return View(evento);
            }

            await _Eventosrepositories.Update(evento);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var evento = await _Eventosrepositories.GetById(id);
            if (evento == null) return NotFound();
            return View(evento);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _Eventosrepositories.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
