using AppProcesso.DbContext;
using AppProcesso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;

namespace AppProcesso.Controllers;

public class ProcessoController : Controller
{
    private readonly AppDbContext _context;
    private readonly HttpClient _httpClient;

    public ProcessoController(AppDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        int pageSize = 10;
        var processos = await _context.Processos
            .Select(p => new ProcessoListViewModel
            {
                Id = p.Id,
                Npu = p.Npu,
                DataCadastro = p.DataCadastro,
                UF = p.UF,
                DataVisualizacao = p.DataVisualizacao,
                Municipio = p.Municipio

            })
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewBag.TotalPages = (int)Math.Ceiling((double)_context.Processos.Count() / pageSize);
        ViewBag.CurrentPage = page;
        return View(processos);
    }
    /// <summary>
    /// Action dos Detalhes do Processo
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Detalhes(Int64 id)
    {
        var processo = await _context.Processos.FindAsync(id);
        if (processo == null)
        {
            return NotFound();
        }
        return View(processo);
    }

    /// <summary>
    /// Action da Criação do Processo
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Create()
    {
        return View();
    }

    /// <summary>
    /// Action Post da criação do Processo
    /// </summary>
    /// <param name="processo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(Processo processo)
    {
        if (ModelState.IsValid)
        {
            string vNpu = processo.Npu;
            processo.Npu = new string(vNpu.Where(char.IsDigit).ToArray());
            _context.Add(processo);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Processo criado com sucesso!";
            return RedirectToAction(nameof(Create));
        }
        else
        {
            ModelState.AddModelError("", "Não foi possível realizar o cadastro do processo.");

        }
        return View(processo);
    }

    /// <summary>
    /// Action para Edição do Processo
    /// </summary>
    /// <param name="id"></param>
    /// <param name="processo"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Edit(Int64 id, Processo processo)
    {
        if (id != processo.Id)
            return NotFound();

        try
        {
            string? vNpu = processo.Npu;
            processo.Npu = new string(vNpu.Where(char.IsDigit).ToArray());
            _context.Update(processo);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProcessoExists(processo.Id))
                return NotFound();
            else
                throw;
        }
        return RedirectToAction(nameof(Index));


    }
    /// <summary>
    /// Action para apagar Processo
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Delete(Int64 id)
    {
        var processo = await _context.Processos.FindAsync(id);
        _context.Processos.Remove(processo);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProcessoExists(Int64 id)
    {
        return _context.Processos.Any(e => e.Id == id);
    }
}
