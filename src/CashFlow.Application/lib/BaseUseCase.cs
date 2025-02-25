namespace CashFlow.Application.lib
{
    public abstract class BaseUseCase<T, K, G> where K : BaseRequest where G : BaseResponse<T>
    {
        public async Task<G> Execute(K input)
        {
            if (!input.IsValid)
            {
                var output = (G)new BaseResponse<T>();
                output.AddErrors(input.Errors);
                return output;
            }

            return await BussinesRole(input);
        }

        internal abstract Task<G> BussinesRole(K input);
    }
}
