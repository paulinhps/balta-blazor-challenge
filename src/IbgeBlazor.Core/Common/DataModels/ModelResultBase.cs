

namespace IbgeBlazor.Core.Common.DataModels
{
    public abstract class ModelResultBase
    {
        public List<ErrorModel> Errors { get; set;} = new List<ErrorModel>();
        public string? Message { get; set; }
        public virtual bool? Success => Errors.Count == 0;

        protected ModelResultBase(string message, params ErrorModel[] errors)
        {
            Message = message;
            Errors.AddRange(errors);
        }

        public ModelResultBase()
        {
            
        }


    }
}