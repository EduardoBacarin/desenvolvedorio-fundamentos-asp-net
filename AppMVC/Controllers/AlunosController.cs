using AppMVC.Data;
using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")] Aluno aluno)
        {
            if (ModelState.IsValid) { 
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }

        public async Task<IActionResult> Details(int id)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(m => m.Id == id);
            return View(aluno);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(m => m.Id == id);
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DataNascimento,Email,Avaliacao,Ativo")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            ModelState.Remove("EmailConfirmacao");
            if (ModelState.IsValid)
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }

    }
}
