using AppMVC.Data;
using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class TesteEFController : Controller
    {
        public AppDbContext Db { get; set; }

        public TesteEFController(AppDbContext db)
        {
            Db = db;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno()
            {
                Name = "Eduardo",
                Email = "eduardo@gmail.com",
                DataNascimento = new DateTime(1994, 12, 21),
                Avaliacao = 5,
                Ativo = true
            };

            /*Cria Aluno no Banco*/
            Db.Alunos.Add(aluno);
            Db.SaveChanges();

            /*Busca o Aluno com nome de Eduardo no banco*/

            /*IGUAL*/
            var alunosChange = Db.Alunos.Where(a => a.Name == "Eduardo").FirstOrDefault();
            
            /*CONTÉM*/
            var alunosChangeContains = Db.Alunos.Where(a => a.Name.Contains("Eduardo")).FirstOrDefault();

            /*Atualiza o nome do aluno*/
            alunosChange.Name = "Eduardo Bacarin";
            Db.Alunos.Update(alunosChange);
            Db.SaveChanges();

            /*Deleta o aluno*/
            Db.Alunos.Remove(alunosChange);
            Db.SaveChanges();

            return View();
        }
    }
}
