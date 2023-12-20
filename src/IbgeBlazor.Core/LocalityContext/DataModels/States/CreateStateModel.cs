using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IbgeBlazor.Core.LocalityContext.DataModels.States;

public record CreateStateModel : RequestModel
{

    [DisplayName("Id para UF do IBGE")]
    [Required(ErrorMessage = "Id para UF do IBGE e obrigatório")]
    [Range(1, 99, ErrorMessage = "Código de Ibge é invalido")]
    public int IbgeUfId { get; set; }

    [DisplayName("Código de UF")]
    [Required(ErrorMessage = "Código de UF é obrigatório")]
    [RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "O Código de UF deve ser duas letras maiusculas")]
    public string Uf { get; set; } = null!;

    [DisplayName("Nome do Estado")]
    [Required(ErrorMessage = "Nome do Estado é obrigatório!")]
    [MaxLength(80, ErrorMessage = "Nome do Estado não deve passar de 80 caractes!")]
    public string Description { get; set; } = null!;
}