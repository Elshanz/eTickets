using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Models;
using eTickets.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _actorService;
        private readonly IUnitOfWork _unitOfWork;
        public ActorsController(IActorService actorService, IUnitOfWork unitOfWork)
        {
            _actorService = actorService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _actorService.GetAllAsync();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl, FullName, Bio")]Actor actor)
        {
            if (!ModelState.IsValid) return View(actor);
            await _actorService.AddAsync(actor);
            await _unitOfWork.CommitAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _actorService.GetByIdAsync(id);
            if (result is null) return View("NotFound");

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _actorService.GetByIdAsync(id);
            if (result is null) return View("NotFound");
            
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureUrl, FullName, Bio")] Actor actor)
        {
            if (!ModelState.IsValid) return View(actor);
            await _actorService.UpdateAsync(id, actor);
            await _unitOfWork.CommitAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _actorService.GetByIdAsync(id);
            if (result is null) return View("NotFound");

            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _actorService.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
