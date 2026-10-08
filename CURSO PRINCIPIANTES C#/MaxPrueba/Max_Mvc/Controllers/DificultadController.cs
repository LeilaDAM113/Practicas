
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Max_Mvc.Models;
using Max_Mvc.DTOs;

public class DificultadController : Controller
{
    private readonly MaxDbContext _context;

	public DificultadController(MaxDbContext context)
	{
		_context = context;
	}

	// GET: Dificultad
	public async Task<IActionResult> Index()
	{

		// =========================================================================
		// BLOQUE 0: INICIALIZACIÓN COMÚN
		// =========================================================================
		// Variables base necesarias para consultar la base de datos.
		MDificultad dificultad = new MDificultad();
		IList<MDificultad> dificultades = new List<MDificultad>();

		// Consultamos de forma asíncrona todos los registros de la tabla de dificultades
		dificultades = await _context.MDificultad.ToListAsync();

		// =========================================================================
		// BLOQUE 1: PRUEBA CON "MDificultad" (Entidad directa de Base de Datos)
		// =========================================================================
		// Descomenta la línea de abajo si quieres probar el envío directo del modelo.
		// NOTA: Si usas esto, tu vista Index.cshtml debe empezar con: @model IEnumerable<Max_Mvc.Models.MDificultad>

		// return View(dificultades); 


		// =========================================================================
		// BLOQUE 2: PRUEBA CON "DificultadDTO" (Mapeo a Objeto de Transferencia)
		// =========================================================================
		// Comenta todo este bloque completo si vas a activar el retorno del BLOQUE 1.
		// NOTA: Si usas esto, tu vista Index.cshtml debe empezar con: @model IEnumerable<Max_Mvc.DTOs.DificultadDTO>

		// 1. Inicializamos la lista donde guardaremos los DTOs transformados
		IList<DificultadDTO> dificultadesDTO = new List<DificultadDTO>();

		// 2. Recorremos cada registro real de la base de datos y copiamos sus datos al DTO
		//Volcamos todo el contenido de los objetos
		//en los nuevos objetos DificultadDTO que vamos creando
		foreach (var item in dificultades)
		{
			DificultadDTO dificultadDTO = new DificultadDTO();
			dificultadDTO.Id = item.Id;
			dificultadDTO.Descripcion = item.Descripcion;

			// Agregamos el DTO ya relleno a nuestra lista temporal
			dificultadesDTO.Add(dificultadDTO);
		}

		// 3. Enviamos la lista de DTOs mapeados a la vista
		return View(dificultadesDTO);
	}

	// GET: Dificultad/Details/5
	public async Task<IActionResult> Details(int id)
	{
		if (id == null) return NotFound();

		var mdificultad = await _context.MDificultad.FirstOrDefaultAsync(m => m.Id == id);
		if (mdificultad == null) return NotFound();

		return View(mdificultad);
	}

	// GET: Dificultad/Create
	public IActionResult Create()
	{
		return View();
	}

	// POST: Dificultad/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("Descripcion")] MDificultad mdificultad)
	{
		// Nota: Se removió "Id" del Bind porque es AUTOINCREMENTABLE en la base de datos
		if (ModelState.IsValid)
		{
			try
			{
				_context.Add(mdificultad);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateException ex)
			{
				ModelState.AddModelError("", "Error al guardar en la base de datos: " + ex.InnerException?.Message);
			}
		}
		return View(mdificultad);
	}

	// GET: Dificultad/Edit/5
	public async Task<IActionResult> Edit(int id)
	{
		if (id == null) return NotFound();

		var mdificultad = await _context.MDificultad.FindAsync(id);
		if (mdificultad == null) return NotFound();

		return View(mdificultad);
	}

	// POST: Dificultad/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,FEjercicio")] MDificultad mdificultad)
	{
		if (id != mdificultad.Id) return NotFound();

		if (ModelState.IsValid)
		{
			try
			{
				_context.Update(mdificultad);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MDificultadExists(mdificultad.Id)) return NotFound();
				else throw;
			}
			return RedirectToAction(nameof(Index));
		}
		return View(mdificultad);
	}

	// GET: Dificultad/Delete/5
	public async Task<IActionResult> Delete(int id)
	{
		if (id == null) return NotFound();

		var mdificultad = await _context.MDificultad.FirstOrDefaultAsync(m => m.Id == id);
		if (mdificultad == null) return NotFound();

		return View(mdificultad);
	}

	// POST: Dificultad/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var mdificultad = await _context.MDificultad.FindAsync(id);
		if (mdificultad != null) _context.MDificultad.Remove(mdificultad);

		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}

	private bool MDificultadExists(int id)
	{
		return _context.MDificultad.Any(e => e.Id == id);
	}
}
