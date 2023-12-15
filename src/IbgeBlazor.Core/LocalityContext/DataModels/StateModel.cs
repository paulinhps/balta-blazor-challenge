namespace IbgeBlazor.Core.LocalityContext.DataModels
{
    public record StateModel
    {
        public int? Id { get; set; }
        public string? Uf { get; set; }
        public string? Description { get; set; }
    }
}