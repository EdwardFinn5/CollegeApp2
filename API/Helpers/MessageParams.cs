namespace API.Helpers
{
    public class MessageParams : ColPaginationParams
    {
        public string ColUsername { get; set; }
        public string Container { get; set; }
    }
}