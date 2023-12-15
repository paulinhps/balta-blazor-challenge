
using Flunt.Notifications;

namespace IbgeBlazor.Core.Common.DataModels
{
    public abstract class ModelResultBase
    {
        
        private List<IErrorModel> _errors = [];

        public IReadOnlyCollection<IErrorModel>? Errors => _errors.Any() ? _errors : null;
        public string? Message { get; set; }
        public bool Success => _errors.Count == 0;

        protected ModelResultBase(string message, params IErrorModel[] errors)
        {
            Message = message;
            _errors.AddRange(errors);
        }


    }
}