using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OneStore.Context;
using OneStore.Models;
using ReflectionIT.Mvc.Paging;

namespace OneStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdminRoupasController : Controller
    {
        private readonly AppDbContext _context;

        public AdminRoupasController(AppDbContext context)
        {
            _context = context;
        }

        //// GET: Admin/AdminRoupas
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.T_ROUPA.Include(r => r.Categoria);
        //    return View(await appDbContext.ToListAsync());
        //}

        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "RoupaNome")
        {
            var resultado = _context.T_ROUPA.Include(c => c.Categoria).AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                resultado = resultado.Where(p => p.RoupaNome.Contains(filter));
            }

            var model = await PagingList.CreateAsync(resultado, 5, pageindex, sort, "RoupaNome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        // GET: Admin/AdminRoupas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.T_ROUPA == null)
            {
                return NotFound();
            }

            var roupa = await _context.T_ROUPA
                .Include(r => r.Categoria)
                .FirstOrDefaultAsync(m => m.RoupaId == id);
            if (roupa == null)
            {
                return NotFound();
            }

            return View(roupa);
        }

        // GET: Admin/AdminRoupas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.T_CATEGORIA, "CategoriaId", "CategoriaDescricao");
            return View();
        }

        // POST: Admin/AdminRoupas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoupaId,RoupaNome,RoupaDescricao,RoupaPreco,RoupaUrlImagem,RoupaDestaque,EmEstoque,CategoriaId")] Roupa roupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.T_CATEGORIA, "CategoriaId", "CategoriaDescricao", roupa.CategoriaId);
            return View(roupa);
        }

        // GET: Admin/AdminRoupas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.T_ROUPA == null)
            {
                return NotFound();
            }

            var roupa = await _context.T_ROUPA.FindAsync(id);
            if (roupa == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.T_CATEGORIA, "CategoriaId", "CategoriaNome", roupa.CategoriaId);
            return View(roupa);
        }

        // POST: Admin/AdminRoupas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoupaId,RoupaNome,RoupaDescricao,RoupaPreco,RoupaUrlImagem,RoupaDestaque,EmEstoque,CategoriaId")] Roupa roupa)
        {
            if (id != roupa.RoupaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoupaExists(roupa.RoupaId))
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
            ViewData["CategoriaId"] = new SelectList(_context.T_CATEGORIA, "CategoriaId", "CategoriaNome", roupa.CategoriaId);
            return View(roupa);
        }

        // GET: Admin/AdminRoupas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.T_ROUPA == null)
            {
                return NotFound();
            }

            var roupa = await _context.T_ROUPA
                .Include(r => r.Categoria)
                .FirstOrDefaultAsync(m => m.RoupaId == id);
            if (roupa == null)
            {
                return NotFound();
            }

            return View(roupa);
        }

        // POST: Admin/AdminRoupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.T_ROUPA == null)
            {
                return Problem("Entity set 'AppDbContext.T_ROUPA'  is null.");
            }
            var roupa = await _context.T_ROUPA.FindAsync(id);
            if (roupa != null)
            {
                _context.T_ROUPA.Remove(roupa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoupaExists(int id)
        {
          return _context.T_ROUPA.Any(e => e.RoupaId == id);
        }
    }
}
