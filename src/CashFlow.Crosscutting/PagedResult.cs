namespace CashFlow.Crosscutting
{
    public class PagedResult<T>
    {
        public int RowCount { get; set; }
        public IList<T> Rows { get; set; }
    }
}
