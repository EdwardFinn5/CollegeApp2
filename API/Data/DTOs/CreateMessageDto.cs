namespace API.Data.DTOs
{
    public class CreateMessageDto
    {
        public string RecipientColUsername { get; set; }
        public string RecipientFirstName { get; set; }
        public string Content { get; set; }
    }
}