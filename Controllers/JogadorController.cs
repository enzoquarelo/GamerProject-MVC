using Microsoft.AspNetCore.Mvc;
using GamerProject_MVC.Infra;
using GamerProject_MVC.Models;

namespace GamerProject_MVC.Controllers
{
    [Route("[controller]")]
    public class JogadorController : Controller
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        Context c = new Context();

        public IActionResult Index()
        {
            ViewBag.Jogador = c.Jogador.ToList();
            ViewBag.Equipe = c.Equipe.ToList();

            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();

            novoJogador.Nome = form["Nome"].ToString();
            novoJogador.Email = form["Email"].ToString();
            novoJogador.Senha = form["Senha"].ToString();

            c.Jogador.Add(novoJogador);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            Jogador jogadorExcluir = c.Jogador.FirstOrDefault(e => e.IdJogador == id);
            

            c.Remove(jogadorExcluir);

            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            Jogador jogadorBuscado = c.Jogador.FirstOrDefault(j => j.IdJogador == id);

            ViewBag.Jogador = jogadorBuscado;

            return View("Editar");
        }

                [Route("Atualizar")]
        public IActionResult Atualizar (IFormCollection form)
        {
            Jogador jogadorAtualizada = new Jogador();

            jogadorAtualizada.IdJogador = int.Parse(form["IdJogador"].ToString());
            jogadorAtualizada.Nome = form["Nome"].ToString();

            Jogador jogadorProcurado = c.Jogador.First(j => j.IdJogador == jogadorAtualizada.IdJogador);

            jogadorAtualizada.Nome = jogadorAtualizada.Nome;

            c.Jogador.Update(jogadorAtualizada);
            
            c.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}