using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IbgeBlazor.Core.LocalityContext.DataModels
{
    public record  CreateCityModel : RequestModel
    {
        [DisplayName("Codigo de cadastro do IBGE")]
        [Required(ErrorMessage = "Codigo de cadastro é obrigatório")]
        public int IbgeCode { get; set; }
        [DisplayName("Nome Cidade")]
        [Required(ErrorMessage = "Nome Cidade é obrigatório")]
        public string CityName { get; set; }
        [DisplayName("UF")]
        [Required(ErrorMessage = "UF é obrigatório")]
        public int UfCode { get; set; }
    }
}
