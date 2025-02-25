using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CashFlow.Application.lib
{
    public class BasePagedResponse<T> : BaseResponse<T>
    {
        public BasePagedResponse()
        {
            Errors = new List<string>();
        }

        public BasePagedResponse(T data) : base(data)
        {
            Data = data;
        }

        public PageSummary Summary { get; set; }
    }
}
