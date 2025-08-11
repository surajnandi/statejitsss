namespace statejitsss.Helpers
{
    public class DapperQueryParameter
    {
        public string? GlobalSearch { get; set; }
        public Dictionary<string, object> Filters { get; set; } = new();
        public Dictionary<string, object> Sorts { get; set; } = new();
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class PagedResult<T>
    {
        public long TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
