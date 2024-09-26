using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ban_Di_Dong.Data;

namespace Ban_Di_Dong.Controllers
{
    public class TbProductsController : Controller
    {
        private readonly BanDienThoaiContext _context;

        public TbProductsController(BanDienThoaiContext context)
        {
            _context = context;
        }

        // GET: TbProducts
        public async Task<IActionResult> Index()
        {
            var banDienThoaiContext = _context.TbProducts.Include(t => t.Cate).Include(t => t.Supplier);
            return View(await banDienThoaiContext.ToListAsync());
        }

        // GET: TbProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProduct = await _context.TbProducts
                .Include(t => t.Cate)
                .Include(t => t.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tbProduct == null)
            {
                return NotFound();
            }

            return View(tbProduct);
        }

        // GET: TbProducts/Create
        public IActionResult Create()
        {
            ViewData["CateId"] = new SelectList(_context.TbCategories, "CateId", "CateId");
            ViewData["SupplierId"] = new SelectList(_context.TbSuppliers, "SupplierId", "SupplierId");
            return View();
        }

        // POST: TbProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Image,Price,StockQuantity,Warranty,Description,CateId,SupplierId")] TbProduct tbProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CateId"] = new SelectList(_context.TbCategories, "CateId", "CateId", tbProduct.CateId);
            ViewData["SupplierId"] = new SelectList(_context.TbSuppliers, "SupplierId", "SupplierId", tbProduct.SupplierId);
            return View(tbProduct);
        }

        // GET: TbProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProduct = await _context.TbProducts.FindAsync(id);
            if (tbProduct == null)
            {
                return NotFound();
            }
            ViewData["CateId"] = new SelectList(_context.TbCategories, "CateId", "CateId", tbProduct.CateId);
            ViewData["SupplierId"] = new SelectList(_context.TbSuppliers, "SupplierId", "SupplierId", tbProduct.SupplierId);
            return View(tbProduct);
        }

        // POST: TbProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Image,Price,StockQuantity,Warranty,Description,CateId,SupplierId")] TbProduct tbProduct)
        {
            if (id != tbProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbProductExists(tbProduct.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CateId"] = new SelectList(_context.TbCategories, "CateId", "CateId", tbProduct.CateId);
            ViewData["SupplierId"] = new SelectList(_context.TbSuppliers, "SupplierId", "SupplierId", tbProduct.SupplierId);
            return View(tbProduct);
        }

        // GET: TbProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbProduct = await _context.TbProducts
                .Include(t => t.Cate)
                .Include(t => t.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tbProduct == null)
            {
                return NotFound();
            }

            return View(tbProduct);
        }

        // POST: TbProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbProduct = await _context.TbProducts.FindAsync(id);
            if (tbProduct != null)
            {
                _context.TbProducts.Remove(tbProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbProductExists(int id)
        {
            return _context.TbProducts.Any(e => e.ProductId == id);
        }
    }
}
