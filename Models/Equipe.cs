using System.ComponentModel.DataAnnotations;

namespace gamer_project_MVC.Models
{
    public class Equipe
    {
        // informando que a informação abaixo é uma chave primaria (PK):
        [Key] // DATA ANNOTATION - IdEquipe
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; } // nome da imagem + extensao. ex: barcelona.png
        public ICollection<Jogador> Jogador { get; set; } // referência da classe equipe para ter acesso a classe jogadores
    }
}