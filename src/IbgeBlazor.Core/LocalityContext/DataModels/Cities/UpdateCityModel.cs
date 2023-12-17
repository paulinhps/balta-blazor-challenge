using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IbgeBlazor.Core.LocalityContext.DataModels.Cities;

public class UpdateCityModel
{

    [DisplayName("Nome Cidade")]
    [Required(ErrorMessage = "Nome Cidade é obrigatório")]
    public string CityName { get; set; } = null!;

}