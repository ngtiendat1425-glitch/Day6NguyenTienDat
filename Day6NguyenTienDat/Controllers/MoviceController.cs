using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day6NguyenTienDat.Data;
using Day6NguyenTienDat.Models;

namespace Day6NguyenTienDat.Controllers
{
    public class MoviceController : Controller
    {
        private readonly Day6NguyenTienDatContext _context;

        public MoviceController(Day6NguyenTienDatContext context)
        {
            _context = context;
        }

        // GET: Movice
        public async Task<IActionResult> Index()
        {
            var day6NguyenTienDatContext = _context.Movice
                .Include(m => m.Genre);

            return View(await day6NguyenTienDatContext.ToListAsync());
        }

        // GET: Movice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movice = await _context.Movice
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movice == null)
            {
                return NotFound();
            }

            return View(movice);
        }

        // GET: Movice/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(
                _context.Genre, "Id", "Name"
            );

            return View();
        }

        // POST: Movice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Title,ReleaseDate,Duration,GenreId")] Movice movice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movice);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["GenreId"] = new SelectList(
                _context.Genre, "Id", "Name", movice.GenreId
            );

            return View(movice);
        }

        // GET: Movice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movice = await _context.Movice.FindAsync(id);

            if (movice == null)
            {
                return NotFound();
            }

            ViewData["GenreId"] = new SelectList(
                _context.Genre, "Id", "Name", movice.GenreId
            );

            return View(movice);
        }

        // POST: Movice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Title,ReleaseDate,Duration,GenreId")] Movice movice)
        {
            if (id != movice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviceExists(movice.Id))
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

            ViewData["GenreId"] = new SelectList(
                _context.Genre, "Id", "Name", movice.GenreId
            );

            return View(movice);
        }

        // GET: Movice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movice = await _context.Movice
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movice == null)
            {
                return NotFound();
            }

            return View(movice);
        }

        // POST: Movice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movice = await _context.Movice.FindAsync(id);

            if (movice != null)
            {
                _context.Movice.Remove(movice);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool MoviceExists(int id)
        {
            return _context.Movice.Any(e => e.Id == id);
        }
    }
}