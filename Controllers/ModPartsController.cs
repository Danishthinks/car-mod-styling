using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Car_Mod_net.Data;
using Car_Mod_net.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Mod_net.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ModPartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModPartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ModParts
        public async Task<IActionResult> Index()
        {
            var parts = await _context.ModParts
                .Include(mp => mp.VehicleModParts)
                    .ThenInclude(vmp => vmp.Vehicle)
                .ToListAsync();
            return View(parts);
        }

        // GET: ModParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modPart = await _context.ModParts
                .Include(mp => mp.VehicleModParts)
                    .ThenInclude(vmp => vmp.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modPart == null)
            {
                return NotFound();
            }

            return View(modPart);
        }

        // GET: ModParts/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Vehicles = await _context.Vehicles.ToListAsync();
            return View();
        }

        // POST: ModParts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Category,Name,Price,ImageUrl,Description")] ModPart modPart, int[] selectedVehicleIds)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modPart);
                await _context.SaveChangesAsync(); // Saves to get modPart.Id

                if (selectedVehicleIds != null && selectedVehicleIds.Length > 0)
                {
                    foreach (var vehicleId in selectedVehicleIds)
                    {
                        _context.VehicleModParts.Add(new VehicleModPart
                        {
                            ModPartId = modPart.Id,
                            VehicleId = vehicleId
                        });
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Vehicles = await _context.Vehicles.ToListAsync();
            return View(modPart);
        }

        // GET: ModParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modPart = await _context.ModParts
                .Include(mp => mp.VehicleModParts)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modPart == null)
            {
                return NotFound();
            }

            ViewBag.Vehicles = await _context.Vehicles.ToListAsync();
            return View(modPart);
        }

        // POST: ModParts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Category,Name,Price,ImageUrl,Description")] ModPart modPart, int[] selectedVehicleIds)
        {
            if (id != modPart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modPart);

                    // Remove existing compatibility links
                    var existingLinks = _context.VehicleModParts.Where(vmp => vmp.ModPartId == id);
                    _context.VehicleModParts.RemoveRange(existingLinks);
                    await _context.SaveChangesAsync();

                    // Add new compatibility links
                    if (selectedVehicleIds != null && selectedVehicleIds.Length > 0)
                    {
                        foreach (var vehicleId in selectedVehicleIds)
                        {
                            _context.VehicleModParts.Add(new VehicleModPart
                            {
                                ModPartId = id,
                                VehicleId = vehicleId
                            });
                        }
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModPartExists(modPart.Id))
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
            ViewBag.Vehicles = await _context.Vehicles.ToListAsync();
            return View(modPart);
        }

        // GET: ModParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modPart = await _context.ModParts
                .Include(mp => mp.VehicleModParts)
                    .ThenInclude(vmp => vmp.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (modPart == null)
            {
                return NotFound();
            }

            return View(modPart);
        }

        // POST: ModParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modPart = await _context.ModParts.FindAsync(id);
            if (modPart != null)
            {
                _context.ModParts.Remove(modPart);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ModPartExists(int id)
        {
            return _context.ModParts.Any(e => e.Id == id);
        }
    }
}
