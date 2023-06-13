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

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

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
            novoJogador.IdEquipe = int.Parse(form["Equipe"].ToString());

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
            ViewBag.Equipe = c.Equipe.ToList();

            return View("Editar");
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form)
        {
            Jogador jogadorAtualizada = new Jogador();

            jogadorAtualizada.IdJogador = int.Parse(form["IdJogador"].ToString());
            jogadorAtualizada.IdEquipe = int.Parse(form["IdEquipe"].ToString());
            jogadorAtualizada.Nome = form["Nome"].ToString();
            jogadorAtualizada.Email = form["Email"].ToString();

            Jogador jogadorProcurado = c.Jogador.First(j => j.IdJogador == jogadorAtualizada.IdJogador);

            jogadorProcurado.Nome = jogadorAtualizada.Nome;
            jogadorProcurado.Email = jogadorAtualizada.Email;
            jogadorProcurado.IdEquipe = jogadorAtualizada.IdEquipe;

            c.Jogador.Update(jogadorProcurado);

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