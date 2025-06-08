using Intranet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Controllers;

[Authorize(Roles = "Admin")]
public class PortalTextsController : Controller
{
    private readonly IntranetContext _context;

    public PortalTextsController(IntranetContext context)
    {
        _context = context;
    }

    // GET: PortalTexts/Sections
    public async Task<IActionResult> Sections()
    {
        var sections = await _context.PortalTexts
            .GroupBy(t => t.Section)
            .Select(g => new SectionViewModel { Name = g.Key, Count = g.Count() })
            .OrderBy(s => s.Name)
            .ToListAsync();
        return View(sections);
    }

    // GET: PortalTexts
    public async Task<IActionResult> Index(string? section)
    {
        var sections = await _context.PortalTexts
            .Select(t => t.Section)
            .Distinct()
            .OrderBy(s => s)
            .ToListAsync();
        ViewBag.Sections = sections;

        var textsQuery = _context.PortalTexts.AsQueryable();
        if (!string.IsNullOrEmpty(section))
        {
            textsQuery = textsQuery.Where(t => t.Section == section);
            ViewBag.CurrentSection = section;
        }
        var texts = await textsQuery.ToListAsync();
        return View(texts);
    }

    // GET: PortalTexts/Create
    public IActionResult Create()
    {
        return View(new PortalText());
    }

    // POST: PortalTexts/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Key,Value,Section")] PortalText text)
    {
        if (ModelState.IsValid)
        {
            _context.PortalTexts.Add(text);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(text);
    }

    // GET: PortalTexts/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var text = await _context.PortalTexts.FindAsync(id);
        if (text == null) return NotFound();
        return View(text);
    }

    // POST: PortalTexts/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Key,Value,Section")] PortalText text)
    {
        if (id != text.Id) return BadRequest();

        if (ModelState.IsValid)
        {
            _context.Update(text);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(text);
    }

    // GET: PortalTexts/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var text = await _context.PortalTexts.FindAsync(id);
        if (text == null) return NotFound();
        return View(text);
    }

    // POST: PortalTexts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var text = await _context.PortalTexts.FindAsync(id);
        if (text != null)
        {
            _context.PortalTexts.Remove(text);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
