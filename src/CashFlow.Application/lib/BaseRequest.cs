namespace CashFlow.Application.lib
{
    public abstract class BaseRequest
    {
        internal bool IsValid
        {
            get
            {
                Validate();
                return Errors.Count == 0;
            }
        }
        internal IList<string> Errors { get; set; }

        internal abstract void Validate();
    }
}
