using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beverage.Shop.web.Data;
using Shop.entites;
using Beverage.Shop.web.Models.Drinks;
using AutoMapper;

namespace Beverage.Shop.web.Controllers
{
    public class DrinksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DrinksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Drinks
        public async Task<IActionResult> Index()
        {
            var drinks = await _context
                                  .Drinks
                                  .ToListAsync();

            var drinksVM = _mapper.Map<List<Drink>, List<DrinkListViewModel>>(drinks);

            return View(drinksVM);
        }

        // GET: Drinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Drinks == null)
            {
                return NotFound();
            }

            var drink = await _context.
                               Drinks.
                               FirstOrDefaultAsync(d => d.Id == id);

            if (drink == null)
            {
                return NotFound();
            }

            var drinkVM = _mapper.Map<Drink, DrinkDetailsViewModel>(drink);

            return View(drinkVM);
        }

        // GET: Drinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DrinkViewModel drinkVM)
        {
            if (ModelState.IsValid)
            {
                var drink = _mapper.Map<DrinkViewModel,Drink >(drinkVM);

                _context.Add(drink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            

            return View(drinkVM);
        }

        // GET: Drinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drinks == null)
            {
                return NotFound();
            }

            var drink = await _context.Drinks.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }
            var drinkVM = _mapper.Map< Drink, DrinkViewModel >(drink);

            return View(drinkVM);
        }

        // POST: Drinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  DrinkViewModel drinkVM)
        {
            if (id != drinkVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var drink = _mapper.Map<DrinkViewModel, Drink >(drinkVM);
                try
                {
                    _context.Update(drink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrinkExists(drink.Id))
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
            return View(drinkVM);
        }

        // GET: Drinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Drinks == null)
            {
                return NotFound();
            }

            var drink = await _context.Drinks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drink == null)
            {
                return NotFound();
            }
            var drinkVM = _mapper.Map<Drink, DrinkViewModel>(drink);

            return View(drinkVM);
        }

        // POST: Drinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Drinks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Drinks'  is null.");
            }
            var drink = await _context.Drinks.FindAsync(id);
            if (drink != null)
            {

                
                _context.Drinks.Remove(drink);

            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrinkExists(int id)
        {
          return (_context.Drinks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
