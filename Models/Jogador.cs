using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamerProject_MVC.Models
{
    public class Jogador
    {
        [Key] // informando que a informação abaixo é uma chave primaria (PK):
        public int IdJogador { get; set; } // PK
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        // informando que informação abaixo é uma chave estrangeira (FK)
        [ForeignKey("Equipe")] // colocar nome da classe que deseja fazer a relação como parâmetro
        public int IdEquipe { get; set; } // FK
        public Equipe Equipe { get; set; } // é necessário ter uma propriedade do tipo equipe
    }
}