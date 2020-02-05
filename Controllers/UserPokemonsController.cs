using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokeList.Data;
using PokeList.Models;
using PokeList.Models.ViewModel;

namespace PokeList.Controllers
{
    public class UserPokemonsController : Controller
    {
        // Private field to store user manager
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;

        // Inject user manager into constructor
        public UserPokemonsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Private method to get current user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);



        //// GET: UserPokemons
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            var applicationDbContext = _context.UserPokemon.Include(u => u.Pokemon).Include(u => u.User)
            .Where(up => up.UserId == currentUser.Id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserPokemons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPokemon = await _context.UserPokemon
                .Include(u => u.Pokemon)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPokemon == null)
            {
                return NotFound();
            }

            return View(userPokemon);
        }

        ////GET: UserPokemons/Create
        public async Task<IActionResult> CreateAsync(int id)
        {
            var currentUser = await GetCurrentUserAsync();
            UserPokemon up = new UserPokemon()
            {

                UserId = currentUser.Id,
                PokemonId = id
            };

            if (ModelState.IsValid)
            {
                up.TimeStamp = DateTime.Now;
                _context.Add(up);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", up.UserId);
            return View();
        }

        // POST: UserPokemons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PokemonId,TimeStamp,DateCreated")] UserPokemon userPokemon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPokemon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PokemonId"] = new SelectList(_context.Pokemon, "Id", "Id", userPokemon.PokemonId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", userPokemon.UserId);
            ViewData["DateCreated"] = new SelectList(_context.Pokemon, "Id", "Id", userPokemon.TimeStamp);
            return View(userPokemon);
        }

        // GET: UserPokemons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPokemon = await _context.UserPokemon.FindAsync(id);
            if (userPokemon == null)
            {
                return NotFound();
            }
            ViewData["PokemonId"] = new SelectList(_context.Pokemon, "Id", "Id", userPokemon.PokemonId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", userPokemon.UserId);
            return View(userPokemon);
        }

        // POST: UserPokemons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,PokemonId,TimeStamp")] UserPokemon userPokemon)
        {
            if (id != userPokemon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPokemon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPokemonExists(userPokemon.Id))
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
            ViewData["PokemonId"] = new SelectList(_context.Pokemon, "Id", "Id", userPokemon.PokemonId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", userPokemon.UserId);
            return View(userPokemon);
        }

        // GET: UserPokemons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPokemon = await _context.UserPokemon
                .Include(u => u.Pokemon)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPokemon == null)
            {
                return NotFound();
            }

            return View(userPokemon);
        }

        // POST: UserPokemons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPokemon = await _context.UserPokemon.FindAsync(id);
            _context.UserPokemon.Remove(userPokemon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPokemonExists(int id)
        {
            return _context.UserPokemon.Any(e => e.Id == id);
        }
    }



//    //Stats GET
public Stats()
{
        Stats s = new Stats();
        s.CaughtPokemon = currentUser.Id
       // 2.assign two numbers
       //    --pokemon caught by userId
       //   -- use.count to find the amount

       //---- - get total # of pokemon in DB and subtract it from the number caught

       // 3.pass the viewmodel into the view.


        return View(Stats);
}

}

