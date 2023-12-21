

namespace IbgeBlazor.Core.Common.DataModels
{

    public class ModelResult<TData> : ModelResult
    {

        public TData? Data { get; set; }

        public override bool? Success => Data is { } && base.Success is true; 
        public ModelResult(string message, params ErrorModel[] errors) : base(message, errors)
        {

        }

        public ModelResult(TData? data, string message, params ErrorModel[] errors) : base(message, errors)
        {
            Data = data;
        }

        public ModelResult(TData? data) : this(data, null!, [])
        {
            Data = data;
        }

        public ModelResult() : base()
        {
            
        }

    }
    public class ModelResult : ModelResultBase
    {
        public ModelResult() : base(null!, [])
        {
            
        }
        public ModelResult(string message, params ErrorModel[] errors) : base(message, errors)
        {

        }


    }
}