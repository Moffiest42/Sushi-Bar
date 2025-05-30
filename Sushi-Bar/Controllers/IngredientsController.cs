﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sushi_Bar.Data;
using Sushi_Bar.Models;

public class IngredientsController : Controller
{
    private readonly Sushi_BarContext _context;

    public IngredientsController(Sushi_BarContext context)
    {
        _context = context;
    }

    // GET: Ingredients
    public async Task<IActionResult> Index()
    {
        return View(await _context.Ingredients.ToListAsync());
    }

    // GET: Ingredients/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ingredient = await _context.Ingredients
            .FirstOrDefaultAsync(m => m.Id == id);
        if (ingredient == null)
        {
            return NotFound();
        }

        return View(ingredient);
    }

    // GET: Ingredients/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Ingredients/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,IsAllergen")] Ingredient ingredient)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(ingredient);
    }

    // GET: Ingredients/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ingredient = await _context.Ingredients.FindAsync(id);
        if (ingredient == null)
        {
            return NotFound();
        }
        return View(ingredient);
    }

    // POST: Ingredients/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsAllergen")] Ingredient ingredient)
    {
        if (id != ingredient.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ingredient);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(ingredient.Id))
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
        return View(ingredient);
    }

    // GET: Ingredients/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ingredient = await _context.Ingredients
            .FirstOrDefaultAsync(m => m.Id == id);
        if (ingredient == null)
        {
            return NotFound();
        }

        return View(ingredient);
    }

    // POST: Ingredients/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);
        _context.Ingredients.Remove(ingredient);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool IngredientExists(int id)
    {
        return _context.Ingredients.Any(e => e.Id == id);
    }
}