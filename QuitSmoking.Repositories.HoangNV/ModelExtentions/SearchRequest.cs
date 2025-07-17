namespace QuitSmoking.Repositories.HoangNV
{
    public class SearchRequest
    {
        public int? CurrentPage { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
    }

    public class SearchMessagesRequest : SearchRequest
    {
        public string? Content { get; set; }
        public int EditCount { get; set; }
        public string? SessionReason { get; set; }
    }
}
