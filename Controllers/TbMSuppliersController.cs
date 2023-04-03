using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fujitsu.Models;

namespace Fujitsu.Controllers
{
    public class TbMSuppliersController : Controller
    {
        private readonly TEST_FIDContext _context;

        public TbMSuppliersController(TEST_FIDContext context)
        {
            _context = context;
        }

        // GET: TbMSuppliers
        public async Task<IActionResult> Index(string city, string province, string searchString)
        {
            if(_context.TbMSupplier == null)
            {
                return Problem("Null");
            }

            IQueryable<string> cityQuery = from data in _context.TbMCity
                                           orderby data.City
                                           select data.City;

            IQueryable<string> provinceQuery = from data in _context.TbMCity
                                               orderby data.Province
                                               select data.Province;

            var datas = from data in _context.TbMSupplier
                        select data;

            if(!string.IsNullOrEmpty(searchString))
            {
                datas = datas.Where(s => s.SupplierCode!.Contains(searchString));
            }

            if(!string.IsNullOrEmpty(city))
            {
                datas = datas.Where(x => x.City == city);
            }

            if (!string.IsNullOrEmpty(province))
            {
                datas = datas.Where(x => x.Province == province);
            }

            var resultFilter = new TbMSupplierViewModel
            {
                Cities = new SelectList(await cityQuery.Distinct().ToListAsync()),
                Provinces = new SelectList(await provinceQuery.Distinct().ToListAsync()),
                tbMSuppliers = await datas.ToListAsync()
            };

            return View(resultFilter);
        }

        // GET: TbMSuppliers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMSupplier = await _context.TbMSupplier
                .FirstOrDefaultAsync(m => m.SupplierCode == id);
            if (tbMSupplier == null)
            {
                return NotFound();
            }

            return View(tbMSupplier);
        }

        // GET: TbMSuppliers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbMSuppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierCode,SupplierName,Address,Province,City,Pic")] TbMSupplier tbMSupplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbMSupplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbMSupplier);
        }

        // GET: TbMSuppliers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMSupplier = await _context.TbMSupplier.FindAsync(id);
            if (tbMSupplier == null)
            {
                return NotFound();
            }
            return View(tbMSupplier);
        }

        // POST: TbMSuppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SupplierCode,SupplierName,Address,Province,City,Pic")] TbMSupplier tbMSupplier)
        {
            if (id != tbMSupplier.SupplierCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMSupplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMSupplierExists(tbMSupplier.SupplierCode))
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
            return View(tbMSupplier);
        }

        // GET: TbMSuppliers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMSupplier = await _context.TbMSupplier
                .FirstOrDefaultAsync(m => m.SupplierCode == id);
            if (tbMSupplier == null)
            {
                return NotFound();
            }

            return View(tbMSupplier);
        }

        // POST: TbMSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tbMSupplier = await _context.TbMSupplier.FindAsync(id);
            _context.TbMSupplier.Remove(tbMSupplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMSupplierExists(string id)
        {
            return _context.TbMSupplier.Any(e => e.SupplierCode == id);
        }
    }
}
