using Microsoft.AspNetCore.Mvc;
using GamerProject_MVC.Infra;
using GamerProject_MVC.Models;

namespace GamerProject_MVC.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [TempData]//Disponibiliza uma mensagem lá na VIEW atraves da propriedade MESSAGE foi inserida o retorno da message no METODO LOGAR
        public string Message { get; set; }
        Context c = new Context();

        //todo // INDEX 
        [Route("Login")]
        public IActionResult Index()
        {
            //*esta viewbag foi copiada e colada em todas VIEW INDEX E EDITAR em todos os controllers existentes, HOME, JOGADOR E EQUIPE
            //*Tudo que retornar uma VIEW tem que inserir este dado para mostrar para todas as VIEWS que o jogador esta logado.
            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            return View();
        }
        //todo // ------------------------------------------------------------------------------------------------




        //todo // Método LOGAR
        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            //Recebendo os dados do usuario para efetuar o login   
            string email = form["Email"].ToString();
            string senha = form["Senha"].ToString();

            //se o objeto buscado "J" for igual ao o objeto cadastrado, para ver se existe um usuario cadastrado com estes dados
            Jogador jogadorBuscado = c.Jogador.FirstOrDefault(j => j.Email == email && j.Senha == senha);

            //! Aqui precisamos implementar a sessão // FOI IMPLEMENTADO PARTE DA DOCUMENTAÇÃO NA PROGRAM MAIS INFORMAÇÕES NELA.
            //se for diferente de nulo
            if (jogadorBuscado != null)
            {
                //username = pode ser qualquer nome, mas foi escolhido username. foi inserido o nomeJogador dentro do UserName
                @HttpContext.Session.SetString("UserName", jogadorBuscado.Nome);
                return LocalRedirect("~/");
            }

            //retorno da message que foi criada uma propriedade
            Message = "Dados Inválidos!";
            
            return LocalRedirect("~/Login/Login/");
        }
        

        //MÉTODO DESLOGAR
        [Route("Logout")]
        public IActionResult Logout()
        {
            // remove o usuário logado
            HttpContext.Session.Remove("UserName");
            //Redireciona para o ínicio do site(pasta raíz) e deslogado
            return LocalRedirect("~/");
        }
        //todo // ------------------------------------------------------------------------------------------------

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}