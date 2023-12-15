

namespace IbgeBlazor.Core.Common.DataModels
{

    public class ModelResult<TData> : ModelResultBase
    {

        public TData? Data { get; set; }
        public ModelResult(string message, params IErrorModel[] errors) : base(message, errors)
        {

        }

        public ModelResult(TData data, string message, params IErrorModel[] errors) : base(message, errors)
        {
            Data = data;
        }

    }
}