using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalTaskGNIS.DbCon;
using PracticalTaskGNIS.Models;

namespace PracticalTaskGNIS.Controllers
{
    public class CorporateCustomerController : Controller
    {
        private readonly DBConContext _context;

        public CorporateCustomerController(DBConContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CorporateCustomers.ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corporateCustomer = await _context.CorporateCustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corporateCustomer == null)
            {
                return NotFound();
            }

            return View(corporateCustomer);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName")] CorporateCustomer corporateCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corporateCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corporateCustomer);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corporateCustomer = await _context.CorporateCustomers.FindAsync(id);
            if (corporateCustomer == null)
            {
                return NotFound();
            }
            return View(corporateCustomer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CustomerName")] CorporateCustomer corporateCustomer)
        {
            if (id != corporateCustomer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corporateCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorporateCustomerExists(corporateCustomer.Id))
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
            return View(corporateCustomer);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corporateCustomer = await _context.CorporateCustomers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corporateCustomer == null)
            {
                return NotFound();
            }

            return View(corporateCustomer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var corporateCustomer = await _context.CorporateCustomers.FindAsync(id);
            if (corporateCustomer != null)
            {
                _context.CorporateCustomers.Remove(corporateCustomer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorporateCustomerExists(long id)
        {
            return _context.CorporateCustomers.Any(e => e.Id == id);
        }
    }
}
