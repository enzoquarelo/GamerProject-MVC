using GamerProject_MVC.Infra;
using GamerProject_MVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace GamerProject_MVC.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }

        //Objeto para o acesso a classe Context (necessidade do using)
        Context c = new Context();

        [Route("Listar")] //http://localhost/Equipe/Listar
        public IActionResult Index()
        {
            // Context.cs é o seu caminho de acesso ao Banco de Dados(dar acesso Controller->Context)
            // ViewBag é a responsável por armazenar as equipes listadas do Banco de Dados, retorna a View de Equipe(Front-End)
            ViewBag.Equipe = c.Equipe.ToList();


            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            //instancia o objeto
            Equipe novaEquipe = new Equipe();

            //atribuicao de valores recebidos do formulario
            novaEquipe.Nome = form["Nome"].ToString();
            novaEquipe.Imagem = form["Imagem"].ToString();

            //adiciona objeto na tabela do BD
            c.SaveChanges();

            //retorna para o local chamado a rota de listar(metodo Index)
            return LocalRedirect("~/Equipe/Listar");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}