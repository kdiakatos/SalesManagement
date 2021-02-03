using Microsoft.AspNetCore.Mvc;
using SalesManagement.BusinessLayer.Interfaces;
using SalesManagement.BusinessLayer.Models;
using System;
using System.Threading.Tasks;

namespace SalesManagement.Web.Controllers
{
    public class SellerController : Controller
    {
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _sellerService.GetAllSellersAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _sellerService.GetSellerByIdAsync(id.Value);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SellerId,FirstName,LastName")] SellerModel seller)
        {
            if (ModelState.IsValid)
            {
                await _sellerService.CreateSellerAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            return View(seller);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _sellerService.GetSellerByIdAsync(id.Value);
            if (seller == null)
            {
                return NotFound();
            }
            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SellerId,FirstName,LastName")] SellerModel seller)
        {
            if (id != seller.SellerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _sellerService.UpdateSellerAsync(seller);
                return RedirectToAction(nameof(Index));
            }
            return View(seller);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _sellerService.GetSellerByIdAsync(id.Value);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _sellerService.DeleteSellerAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
