using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalTaskGNIS.DbCon;
using PracticalTaskGNIS.Models;

namespace PracticalTaskGNIS.Controllers;

public class CorporateOrIndividualController : Controller
{
    private readonly DBConContext _context;

    public CorporateOrIndividualController(DBConContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.CorporateOrIndividuals.ToListAsync());
    }


    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var corporateOrIndividual = await _context.CorporateOrIndividuals
            .FirstOrDefaultAsync(m => m.Id == id);
        if (corporateOrIndividual == null)
        {
            return NotFound();
        }

        return View(corporateOrIndividual);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetCustomerNames(string customerType)
    {
        List<string> customerNames = new List<string>();

        if (customerType == "Corporate")
        {
            customerNames = _context.CorporateCustomers.Select(c => c.CustomerName).ToList();
        }
        else if (customerType == "Individual")
        {
            customerNames = _context.IndividualCustomer.Select(c => c.CustomerName).ToList();
        }

        return Json(customerNames);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CorporateOrIndividual corporateOrIndividual)
    {
        if (ModelState.IsValid)
        {
            _context.Add(corporateOrIndividual);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(corporateOrIndividual);
    }

    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var meeting = await _context.CorporateOrIndividuals.FindAsync(id);
        if (meeting == null)
        {
            return NotFound();
        }
        return View(meeting);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long id, CorporateOrIndividual corporateOrIndividual)
    {
        if (id != corporateOrIndividual.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(corporateOrIndividual);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeetingExists(corporateOrIndividual.Id))
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
        return View(corporateOrIndividual);
    }

    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var corporateOrIndividual = await _context.CorporateOrIndividuals
            .FirstOrDefaultAsync(m => m.Id == id);
        if (corporateOrIndividual == null)
        {
            return NotFound();
        }

        return View(corporateOrIndividual);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var corporateOrIndividual = await _context.CorporateOrIndividuals.FindAsync(id);
        if (corporateOrIndividual != null)
        {
            _context.CorporateOrIndividuals.Remove(corporateOrIndividual);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MeetingExists(long id)
    {
        return _context.CorporateOrIndividuals.Any(e => e.Id == id);
    }
}
