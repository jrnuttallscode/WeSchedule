using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeSchedule.Models;

namespace WeSchedule.Controllers
{
    public class EmployeeSetupsController : Controller
    {
        private readonly ScheduleSetup _context;

        public EmployeeSetupsController(ScheduleSetup context)
        {
            _context = context;
        }

        // GET: EmployeeSetups
        public async Task<IActionResult> Index()
        {
            return View(await _context.employeeSetup.ToListAsync());
        }

        // GET: EmployeeSetups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSetup = await _context.employeeSetup
                .FirstOrDefaultAsync(m => m.id == id);
            if (employeeSetup == null)
            {
                return NotFound();
            }

            return View(employeeSetup);
        }

        // GET: EmployeeSetups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeSetups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,dept,position,wage")] EmployeeSetup employeeSetup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeSetup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeSetup);
        }

        // GET: EmployeeSetups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSetup = await _context.employeeSetup.FindAsync(id);
            if (employeeSetup == null)
            {
                return NotFound();
            }
            return View(employeeSetup);
        }

        // POST: EmployeeSetups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,dept,position,wage")] EmployeeSetup employeeSetup)
        {
            if (id != employeeSetup.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeSetup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeSetupExists(employeeSetup.id))
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
            return View(employeeSetup);
        }

        // GET: EmployeeSetups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeSetup = await _context.employeeSetup
                .FirstOrDefaultAsync(m => m.id == id);
            if (employeeSetup == null)
            {
                return NotFound();
            }

            return View(employeeSetup);
        }

        // POST: EmployeeSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeSetup = await _context.employeeSetup.FindAsync(id);
            _context.employeeSetup.Remove(employeeSetup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeSetupExists(int id)
        {
            return _context.employeeSetup.Any(e => e.id == id);
        }
    }
}
