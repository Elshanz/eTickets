using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Data.Services;
using eTickets.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _producerService;
        private readonly IUnitOfWork _unitOfWork;
        public ProducersController(IProducerService producerService, IUnitOfWork unitOfWork)
        {
            _producerService = producerService;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var producers = await _producerService.GetAllAsync();
            return View(producers);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _producerService.GetByIdAsync(id);

            if (producerDetails is null) return View("NotFound");

            return View(producerDetails);
        }
        public async Task<IActionResult> Edit(int id, ProducerToUpdate producerToUpdate)
        {
            var producer = await _producerService.GetByIdAsync(id);

            if (!ModelState.IsValid)
            {
                return View(producerToUpdate);
            }

            producer.ProfilePictureUrl = producerToUpdate.ProfilePictureUrl;
            producer.FullName = producerToUpdate.FullName;
            producer.Bio = producerToUpdate.Bio;

            await _producerService.UpdateAsync(id, producer);

            await _unitOfWork.CommitAsync();

            return View(producer);
        }
    }
}
