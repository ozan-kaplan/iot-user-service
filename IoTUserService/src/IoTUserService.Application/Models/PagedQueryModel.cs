namespace IoTUserService.Application.Models
{
    public class PagedQueryModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; }
        public bool SortAsc { get; set; }

        public Dictionary<string, string>? Filters { get; set; }

        public PagedQueryModel()
        {
            Filters = new Dictionary<string, string>();
        }
    }
     
}
