using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beverage.Shop.web.Data;
using Shop.entites;
using AutoMapper;
using Beverage.Shop.web.Models.FruitsAndSpices;


namespace Beverage.Shop.web.Controllers
{
    public class FruitsAndSpicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FruitsAndSpicesController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: FruitAndSpices
        public async Task<IActionResult> Index()
        {


            var fruitAndspice =await _context
                .FruitsAndSpices
                .Include(f => f.Drink)
                .ToListAsync();
                

            var FruitAndSpiceVM = _mapper.Map<List<FruitAndSpice>, List<FruitAndSpiceListViewModel>>(fruitAndspice);

            return View(FruitAndSpiceVM);
        }

        // GET: FruitAndSpices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FruitsAndSpices == null)
            {
                return NotFound();
            }

            var fruitAndspice = await _context.FruitsAndSpices
                .Include(f => f.Drink)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fruitAndspice == null)
            {
                return NotFound();
            }
            var FruitAndSpiceVM = _mapper.Map<FruitAndSpice, FruitAndSpiceViewModel>(fruitAndspice);

            return View(FruitAndSpiceVM);
        }

        // GET: FruitAndSpices/Create
        public IActionResult Create()
        {
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "DrinkName");
            return View();
        }

        // POST: FruitAndSpices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FruitAndSpiceViewModel FruitAndSpiceVM)
        {
            if (ModelState.IsValid)
            {
                var fruitAndspice = _mapper.Map< FruitAndSpiceViewModel, FruitAndSpice>(FruitAndSpiceVM);
                _context.Add(fruitAndspice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "DrinkName", FruitAndSpiceVM.DrinkId);
            return View(FruitAndSpiceVM);
        }

        // GET: FruitAndSpices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FruitsAndSpices == null)
            {
                return NotFound();
            }

            var fruitAndspice = await _context
                                  .FruitsAndSpices
                                  .FindAsync(id);
            if (fruitAndspice == null)
            {
                return NotFound();
            }

            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "DrinkName", fruitAndspice.DrinkId);

            var FruitAndSpiceVM = _mapper.Map<FruitAndSpice, FruitAndSpiceViewModel>(fruitAndspice);
            return View(FruitAndSpiceVM);
        }

        // POST: FruitAndSpices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FruitAndSpiceViewModel FruitAndSpiceVM)
        {
            if (id != FruitAndSpiceVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var fruitAndspice = _mapper.Map<FruitAndSpiceViewModel, FruitAndSpice >(FruitAndSpiceVM);
               
                try
                {
                    _context.Update(fruitAndspice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FruitAndSpiceExists(fruitAndspice.Id))
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
            ViewData["DrinkId"] = new SelectList(_context.Drinks, "Id", "DrinkName", FruitAndSpiceVM.DrinkId);
            return View(FruitAndSpiceVM);
        }

        // GET: FruitAndSpices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FruitsAndSpices == null)
            {
                return NotFound();
            }

            var fruitAndspice = await _context.FruitsAndSpices
                .Include(f => f.Drink)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fruitAndspice == null)
            {
                return NotFound();
            }
            var FruitAndSpiceVM = _mapper.Map<FruitAndSpice, FruitAndSpiceViewModel>(fruitAndspice);

            return View(FruitAndSpiceVM);
        }

        // POST: FruitAndSpices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FruitsAndSpices == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FruitsAndSpices'  is null.");
            }
            var fruitAndSpice = await _context.FruitsAndSpices.FindAsync(id);
            if (fruitAndSpice != null)
            {
                _context.FruitsAndSpices.Remove(fruitAndSpice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FruitAndSpiceExists(int id)
        {
          return (_context.FruitsAndSpices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
