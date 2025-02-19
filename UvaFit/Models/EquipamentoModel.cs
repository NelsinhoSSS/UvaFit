using System.ComponentModel.DataAnnotations;
using UvaFit.Enums;

namespace UvaFit.Models
{
    public class EquipamentoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do equipamento")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o status do equipamento")]
        public SituacaoEquipamentoEnum SituacaoEquipamento { get; set; }

    }
}
