namespace CashFlow.Application.lib
{
    public abstract class BasePagedRequest : BaseRequest
    {
        public PageSummary Summary { get; set; }
    }
}