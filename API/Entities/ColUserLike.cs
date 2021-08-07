namespace API.Entities
{
    public class ColUserLike
    {
        public ColUser SourceColUser { get; set; }
        public int SourceColUserId { get; set; }

        public ColUser LikedColUser { get; set; }

        public int LikedColUserId { get; set; }
    }
}