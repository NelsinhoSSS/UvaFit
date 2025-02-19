using System.ComponentModel.DataAnnotations;
using UvaFit.Enums;

namespace UvaFit.Models
{
    public class TreinoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do aluno")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o CPF do aluno")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Digite o treino do aluno")]
        public string Treino { get; set; }


    }
}
