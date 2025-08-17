using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecommerce.Database;
using ecommerce.Models;
using ecommerce.Repositories;
using ecommerce.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UnitController : Controller
    {
        private readonly UnitRepository _unitRepository;

        public UnitController(UnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<IActionResult> GetUnits()
        {
            var units = await _unitRepository.GetAllAsync();
            return Json(new { data = units });
        }

        // GET: Admin/Units
        public IActionResult Index()
        {
            return View();
        }

        // GET: Admin/Units/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var unit = new Unit
                {
                    Name = model.Name
                };

                await _unitRepository.AddAsync(unit);
                return Json(new { success = true, message = "Unit added successfully!" });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, message = string.Join(", ", errors) });
        }

        // GET: Admin/Units/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _unitRepository.GetByIdAsync(id.Value);
            if (unit == null)
            {
                return NotFound();
            }
            return Json(new
            {
                success = true,
                data = new UnitViewModel
                {
                    Name = unit.Name
                }
            });
        }

        // POST: Admin/Units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UnitViewModel model)
        {
            var unit = new Unit
            {
                Id = id,
                Name = model.Name
            };

            if (id != unit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitRepository.UpdateAsync(unit);
                    return Json(new { success = true, message = "Unit updated successfully!" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _unitRepository.UnitExistsAsync(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            return Json(new { success = false, message = string.Join(", ", errors) });
        }

        // GET: Admin/Units/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _unitRepository.GetByIdAsync(id.Value);
            if (unit == null)
            {
                return NotFound();
            }

            return Json(new
            {
                success = true,
                message = "Unit deleted successfully!"
            });
        }
        
         // POST: Admin/Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitRepository.DeleteAsync(id);
            return Json(new
            {
                success = true,
                message = "Unit deleted successfully!"
            });
        }
    }
}