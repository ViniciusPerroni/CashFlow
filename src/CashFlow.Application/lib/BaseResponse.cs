namespace CashFlow.Application.lib
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Errors = new List<string>();
        }

        public BaseResponse(T data) : this()
        {
            Data = data;
        }

        public T Data { get; set; }
        public IList<string> Errors { get; set; }
        public bool Ok { get { return Errors.Count == 0; } }

        public void AddError(string error)
        {
            Errors.Add(error);
        }
        public void AddErrors(IList<string> errors)
        {
            ((List<string>)Errors).AddRange(errors);
        }
    }
}
