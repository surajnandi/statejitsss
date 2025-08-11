namespace statejitsss.Helpers
{
    public class FilterCriteria
    {
        public string Field { get; set; }       // Field to filter on (e.g., "Name", "Price")
        public string Operator { get; set; }    // Operator (e.g., // "isnull", "isnotnull" "eq", "lt", "gt", "contains")
        public string Value { get; set; }       // Value to filter by
    }
    public class SortCriteria
    {
        public string Field { get; set; }       // Field to filter on (e.g., "Name", "Price")
        public string Order { get; set; } = "asc"; // "asc" or "desc"
    }

    public class QueryParameters
    {
        public string? GlobalSearch { get; set; }
        public List<FilterCriteria> Filters { get; set; } = new List<FilterCriteria>();
        public List<SortCriteria> Sorts { get; set; } = new List<SortCriteria>();
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class PaginatedResponseObject<T>
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public T Data { get; set; }
        public Dictionary<string, object> MetaData { get; set; } = new();
    }
}
