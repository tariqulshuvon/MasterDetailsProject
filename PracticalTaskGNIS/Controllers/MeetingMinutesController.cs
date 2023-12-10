using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalTaskGNIS.DbCon;
using PracticalTaskGNIS.Models;

namespace PracticalTaskGNIS.Controllers
{
    public class MeetingMinutesController : Controller
    {
        private readonly DBConContext _context;

        public MeetingMinutesController(DBConContext context)
        {
            _context = context;
        }

        // GET: MeetingMinutes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeetingMinutes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingMinutes = await _context.MeetingMinutes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetingMinutes == null)
            {
                return NotFound();
            }

            return View(meetingMinutes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,MeetingPlace")] MeetingMinutes meetingMinutes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingMinutes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meetingMinutes);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingMinutes = await _context.MeetingMinutes.FindAsync(id);
            if (meetingMinutes == null)
            {
                return NotFound();
            }
            return View(meetingMinutes);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,MeetingPlace")] MeetingMinutes meetingMinutes)
        {
            if (id != meetingMinutes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingMinutes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingMinutesExists(meetingMinutes.Id))
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
            return View(meetingMinutes);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingMinutes = await _context.MeetingMinutes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meetingMinutes == null)
            {
                return NotFound();
            }

            return View(meetingMinutes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingMinutes = await _context.MeetingMinutes.FindAsync(id);
            if (meetingMinutes != null)
            {
                _context.MeetingMinutes.Remove(meetingMinutes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingMinutesExists(int id)
        {
            return _context.MeetingMinutes.Any(e => e.Id == id);
        }
    }
}
