using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IbgeBlazor.Core.LocalityContext.DataModels.Cities;

public record CreateCityModel : RequestModel
{
    [DisplayName("Codigo de cadastro do IBGE")]
    [Required(ErrorMessage = "Codigo de cadastro é obrigatório")]
    public string IbgeCode { get; set; } = null!;

    [DisplayName("Nome Cidade")]
    [Required(ErrorMessage = "Nome Cidade é obrigatório")]
    public string CityName { get; set; } = null!;

    [DisplayName("UF")]
    [Required(ErrorMessage = "UF é obrigatório")]
    public int StateId { get; set; }
}
