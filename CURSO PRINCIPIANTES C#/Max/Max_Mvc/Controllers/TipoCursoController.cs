namespace Max_Mvc.Controllers
{
    using global::Max_Mvc.Models;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	namespace Max_Mvc.Controllers
	{
		public class TipoCursoController : Controller
		{
			private readonly MaxDbContext _context;

			public TipoCursoController(MaxDbContext context)
			{
				_context = context;
			}

			// GET: TipoCurso
			public async Task<IActionResult> Index()
			{
				return View(await _context.MTipoCurso.ToListAsync());
			}

			// GET: TipoCurso/Details/5
			public async Task<IActionResult> Details(int? id)
			{
				if (id == null) return NotFound();

				var mTipoCurso = await _context.MTipoCurso.FirstOrDefaultAsync(m => m.Id == id); // Reemplaza 'Id' por tu clave primaria real
				if (mTipoCurso == null) return NotFound();

				return View(mTipoCurso);
			}

			// GET: TipoCurso/Create
			public IActionResult Create()
			{
				return View();
			}

			// POST: TipoCurso/Create
			[HttpPost]
			[ValidateAntiForgeryToken]
			public async Task<IActionResult> Create([Bind("Id,Descripcion")] MTipoCurso mTipoCurso) // Ajusta las propiedades de tu modelo
			{
				if (ModelState.IsValid)
				{
					_context.Add(mTipoCurso);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				return View(mTipoCurso);
			}

			// GET: TipoCurso/Edit/5
			public async Task<IActionResult> Edit(int? id)
			{
				if (id == null) return NotFound();

				var mTipoCurso = await _context.MTipoCurso.FindAsync(id);
				if (mTipoCurso == null) return NotFound();
				return View(mTipoCurso);
			}

			// POST: TipoCurso/Edit/5
			[HttpPost]
			[ValidateAntiForgeryToken]
			public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] MTipoCurso mTipoCurso)
			{
				if (id != mTipoCurso.Id) return NotFound();

				if (ModelState.IsValid)
				{
					try
					{
						_context.Update(mTipoCurso);
						await _context.SaveChangesAsync();
					}
					catch (DbUpdateConcurrencyException)
					{
						if (!TipoCursoExists(mTipoCurso.Id)) return NotFound();
						else throw;
					}
					return RedirectToAction(nameof(Index));
				}
				return View(mTipoCurso);
			}

			// GET: TipoCurso/Delete/5
			public async Task<IActionResult> Delete(int? id)
			{
				if (id == null) return NotFound();

				var mTipoCurso = await _context.MTipoCurso.FirstOrDefaultAsync(m => m.Id == id);
				if (mTipoCurso == null) return NotFound();

				return View(mTipoCurso);
			}

			// POST: TipoCurso/Delete/5
			[HttpPost, ActionName("Delete")]
			[ValidateAntiForgeryToken]
			public async Task<IActionResult> DeleteConfirmed(int id)
			{
				var mTipoCurso = await _context.MTipoCurso.FindAsync(id);
				if (mTipoCurso != null) _context.MTipoCurso.Remove(mTipoCurso);

				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			private bool TipoCursoExists(int id)
			{
				return _context.MTipoCurso.Any(e => e.Id == id);
			}
		}
	}

}
