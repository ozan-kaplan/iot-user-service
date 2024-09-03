namespace IoTUserService.Application.Models
{
    public class PagedResultModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalRecords { get; set; }

        public PagedResultModel(IEnumerable<T> items, int totalRecords)
        {
            Items = items;
            TotalRecords = totalRecords;
        }
    }
}
