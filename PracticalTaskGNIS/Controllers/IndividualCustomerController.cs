using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalTaskGNIS.DbCon;
using PracticalTaskGNIS.Models;

namespace PracticalTaskGNIS.Controllers
{
    public class IndividualCustomerController : Controller
    {
        private readonly DBConContext _context;

        public IndividualCustomerController(DBConContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.IndividualCustomer.ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualCustomer = await _context.IndividualCustomer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (individualCustomer == null)
            {
                return NotFound();
            }

            return View(individualCustomer);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,CustomerName")] IndividualCustomer individualCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(individualCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(individualCustomer);
        }


        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualCustomer = await _context.IndividualCustomer.FindAsync(id);
            if (individualCustomer == null)
            {
                return NotFound();
            }
            return View(individualCustomer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CustomerName")] IndividualCustomer individualCustomer)
        {
            if (id != individualCustomer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(individualCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndividualCustomerExists(individualCustomer.Id))
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
            return View(individualCustomer);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualCustomer = await _context.IndividualCustomer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (individualCustomer == null)
            {
                return NotFound();
            }

            return View(individualCustomer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var individualCustomer = await _context.IndividualCustomer.FindAsync(id);
            if (individualCustomer != null)
            {
                _context.IndividualCustomer.Remove(individualCustomer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndividualCustomerExists(long id)
        {
            return _context.IndividualCustomer.Any(e => e.Id == id);
        }
    }
}
