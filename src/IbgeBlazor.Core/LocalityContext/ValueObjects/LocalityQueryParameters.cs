using Flunt.Notifications;
using Flunt.Validations;
using IbgeBlazor.Core.Common.ValueObjects;


namespace IbgeBlazor.Core.LocalityContext.ValueObjects
{
    public class PaginationQuery : ValueObject
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

            Validate();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            // retorna vazio
            yield break;
        }

        protected override void Validate()
        {
            AddNotifications(new Contract<PaginationQuery>()
                .Requires()
                .IsGreaterOrEqualsThan(PageNumber, 1, nameof(PageNumber), "Pagina Inválida")
                .IsGreaterOrEqualsThan(PageSize, 1, nameof(PageNumber), "Quantidade por página Inválida"));
        }

        public int Take() => Math.Max(1, PageSize);
        public int Skip() => PageNumber > 1 ? Take() * (PageNumber - 1) : 0;
    }
    public class LocalityQueryParameters : PaginationQuery
    {
      

        public string? Term { get; set; }

        public LocalityQueryParameters(string? term, int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
            Term = term;
        }
        protected override void Validate()
        {
           base.Validate();

            AddNotifications(new Contract<LocalityQueryParameters>()
               .Requires()
               .IsFalse(
                string.IsNullOrEmpty(Term), "Term", "Termo Inválido para busca"));
        }

    }
}
