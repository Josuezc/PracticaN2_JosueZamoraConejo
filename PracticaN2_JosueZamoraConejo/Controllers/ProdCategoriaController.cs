using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaN2_JosueZamoraConejo.Models;

namespace PracticaN2_JosueZamoraConejo.Controllers
{
    public class ProdCategoriaController : Controller
    {
        private readonly FructicaDBContext _context;

        public ProdCategoriaController(FructicaDBContext context)
        {
            _context = context;
        }

        // GET: ProdCategoria
        public async Task<IActionResult> Index()
        {
            var fructicaDBContext = _context.ProdCategorias.Include(p => p.Categoria).Include(p => p.Producto);
            return View(await fructicaDBContext.ToListAsync());
        }

        // GET: ProdCategoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodCategoria = await _context.ProdCategorias
                .Include(p => p.Categoria)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (prodCategoria == null)
            {
                return NotFound();
            }

            return View(prodCategoria);
        }

        // GET: ProdCategoria/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Descripcion");
            return View();
        }

        // POST: ProdCategoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,CategoriaId")] ProdCategoria prodCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prodCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", prodCategoria.CategoriaId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Descripcion", prodCategoria.ProductoId);
            return View(prodCategoria);
        }

        // GET: ProdCategoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodCategoria = await _context.ProdCategorias.FindAsync(id);
            if (prodCategoria == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", prodCategoria.CategoriaId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Descripcion", prodCategoria.ProductoId);
            return View(prodCategoria);
        }

        // POST: ProdCategoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,CategoriaId")] ProdCategoria prodCategoria)
        {
            if (id != prodCategoria.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prodCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdCategoriaExists(prodCategoria.ProductoId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nombre", prodCategoria.CategoriaId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "Descripcion", prodCategoria.ProductoId);
            return View(prodCategoria);
        }

        // GET: ProdCategoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prodCategoria = await _context.ProdCategorias
                .Include(p => p.Categoria)
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (prodCategoria == null)
            {
                return NotFound();
            }

            return View(prodCategoria);
        }

        // POST: ProdCategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prodCategoria = await _context.ProdCategorias.FindAsync(id);
            if (prodCategoria != null)
            {
                _context.ProdCategorias.Remove(prodCategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdCategoriaExists(int id)
        {
            return _context.ProdCategorias.Any(e => e.ProductoId == id);
        }
    }
}
