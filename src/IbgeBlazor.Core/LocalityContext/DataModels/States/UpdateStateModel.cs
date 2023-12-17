using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IbgeBlazor.Core.LocalityContext.DataModels.States;

public record UpdateStateModel : RequestModel
{
    [DisplayName("Nome do Estado")]
    [Required(ErrorMessage = "Nome do Estado é obrigatório!")]
    [MaxLength(80, ErrorMessage = "Nome do Estado não deve passar de 80 caractes!")]
    public string Description { get; set; } = null!;
}