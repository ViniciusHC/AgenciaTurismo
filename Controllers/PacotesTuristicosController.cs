﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgenciaTurismo.Data;
using AgenciaTurismo.Models;

namespace AgenciaTurismo.Controllers
{
    public class PacotesTuristicosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacotesTuristicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PacotesTuristicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.PacotesTuristicos.ToListAsync());
        }

        // GET: PacotesTuristicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteTuristico = await _context.PacotesTuristicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacoteTuristico == null)
            {
                return NotFound();
            }

            return View(pacoteTuristico);
        }

        // GET: PacotesTuristicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PacotesTuristicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,DataInicio,CapacidadeMaxima,Preco")] PacoteTuristico pacoteTuristico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacoteTuristico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacoteTuristico);
        }

        // GET: PacotesTuristicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteTuristico = await _context.PacotesTuristicos.FindAsync(id);
            if (pacoteTuristico == null)
            {
                return NotFound();
            }
            return View(pacoteTuristico);
        }

        // POST: PacotesTuristicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,DataInicio,CapacidadeMaxima,Preco")] PacoteTuristico pacoteTuristico)
        {
            if (id != pacoteTuristico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacoteTuristico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacoteTuristicoExists(pacoteTuristico.Id))
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
            return View(pacoteTuristico);
        }

        // GET: PacotesTuristicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteTuristico = await _context.PacotesTuristicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pacoteTuristico == null)
            {
                return NotFound();
            }

            return View(pacoteTuristico);
        }

        // POST: PacotesTuristicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacoteTuristico = await _context.PacotesTuristicos.FindAsync(id);
            if (pacoteTuristico != null)
            {
                _context.PacotesTuristicos.Remove(pacoteTuristico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacoteTuristicoExists(int id)
        {
            return _context.PacotesTuristicos.Any(e => e.Id == id);
        }
    }
}
