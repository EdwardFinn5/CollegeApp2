namespace API.Helpers
{
    public class LikesParams : ColPaginationParams
    {
        public int ColUserId { get; set; }
        public string Predicate { get; set; }
    }
}