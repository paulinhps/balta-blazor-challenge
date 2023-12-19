

namespace IbgeBlazor.Core.Common.DataModels
{
    public abstract class ModelResultBase
    {

        public List<IErrorModel> Errors { get; set;} = new List<IErrorModel>();
        public string? Message { get; set; }
        public virtual bool? Success => Errors.Count == 0;

        protected ModelResultBase(string message, params IErrorModel[] errors)
        {
            Message = message;
            Errors.AddRange(errors);
        }

        public ModelResultBase()
        {
            
        }


    }
}