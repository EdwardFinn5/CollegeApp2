using System;

namespace API.Data.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderColUsername { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderCollegeName { get; set; }
        public string SenderHsName { get; set; }
        public string SenderColUserType { get; set; }
        public string SenderHsPhotoUrl { get; set; }
        public string SenderCollegePhotoUrl { get; set; }
        public string RecipientHsPhotoUrl { get; set; }
        public string RecipientCollegePhotoUrl { get; set; }
        public int RecipientId { get; set; }
        public string RecipientColUsername { get; set; }
        public string RecipientFirstName { get; set; }
        public string RecipientCollegeName { get; set; }
        public string RecipientHsName { get; set; }
        public string RecipientColUserType { get; set; }
        public string Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; }
    }
}