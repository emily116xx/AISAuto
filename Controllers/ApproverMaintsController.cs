using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AISAutoForms.Data;
using AISAutoForms.Models;

namespace AISAutoForms.Controllers
{
    public class ApproverMaintsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApproverMaintsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApproverMaints
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApproverMaints.ToListAsync());
        }

        // GET: ApproverMaints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approverMaint = await _context.ApproverMaints
                .FirstOrDefaultAsync(m => m.ApproverId == id);
            if (approverMaint == null)
            {
                return NotFound();
            }

            return View(approverMaint);
        }

        // GET: ApproverMaints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApproverMaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApproverId,ApproverName,ApproverRole,ApproverDept")] ApproverMaint approverMaint)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approverMaint);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(approverMaint);
        }

        // GET: ApproverMaints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approverMaint = await _context.ApproverMaints.FindAsync(id);
            if (approverMaint == null)
            {
                return NotFound();
            }
            return View(approverMaint);
        }

        // POST: ApproverMaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApproverId,ApproverName,ApproverRole,ApproverDept")] ApproverMaint approverMaint)
        {
            if (id != approverMaint.ApproverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approverMaint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApproverMaintExists(approverMaint.ApproverId))
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
            return View(approverMaint);
        }

        // GET: ApproverMaints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approverMaint = await _context.ApproverMaints
                .FirstOrDefaultAsync(m => m.ApproverId == id);
            if (approverMaint == null)
            {
                return NotFound();
            }

            return View(approverMaint);
        }

        // POST: ApproverMaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approverMaint = await _context.ApproverMaints.FindAsync(id);
            if (approverMaint != null)
            {
                _context.ApproverMaints.Remove(approverMaint);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApproverMaintExists(int id)
        {
            return _context.ApproverMaints.Any(e => e.ApproverId == id);
        }
    }
}
