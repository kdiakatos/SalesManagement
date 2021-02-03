using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesManagement.BusinessLayer.Interfaces;
using SalesManagement.BusinessLayer.Models;
using System;
using System.Threading.Tasks;

namespace SalesManagement.Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISellerService _sellerService;
        private readonly ISaleService _saleService;
      
        public SaleController(ISellerService sellerService, ISaleService saleService)
        {
            _sellerService = sellerService;
            _saleService = saleService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _saleService.GetAllSalesAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _saleService.GetSaleByIdAsync(id.Value);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        public async Task<IActionResult> CreateAsync()
        {
            ViewData["SellerId"] = new SelectList(await _sellerService.GetAllSellersAsync(), "SellerId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,SellerId,TransactionAmount,DateOfSale")] SaleModel sale)
        {
            if (ModelState.IsValid)
            {
                await _saleService.CreateSaleAsync(sale);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SellerId"] = new SelectList(await _sellerService.GetAllSellersAsync(), "SellerId", "FullName");
            return View(sale);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _saleService.GetSaleByIdAsync(id.Value);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["SellerId"] = new SelectList(await _sellerService.GetAllSellersAsync(), "SellerId", "FullName");
            return View(sale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SaleId,SellerId,TransactionAmount,DateOfSale")] SaleModel sale)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _saleService.UpdateSaleAsync(sale);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SellerId"] = new SelectList(await _sellerService.GetAllSellersAsync(), "SellerId", "FullName");
            return View(sale);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _saleService.GetSaleByIdAsync(id.Value);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _saleService.DeleteSaleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
