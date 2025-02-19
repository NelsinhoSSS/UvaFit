using System.ComponentModel.DataAnnotations;
using UvaFit.Enums;

namespace UvaFit.Models
{
    public class MatriculaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o seu CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite o seu e-mail")]
        [EmailAddress(ErrorMessage = "Digite um endereço de e-mail válido")]
        public string Email { get; set; }


        public DateTime DataCadastro { get; set; }
        public DateTime DataPagamento { get; set; }
         public SituacaoMatriculaEnum SituacaoMatricula { get; set; }
        public PlanoMatriculaEnum PlanoMatricula { get; set; }
    }
}
