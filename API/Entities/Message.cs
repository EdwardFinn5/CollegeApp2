using System;

namespace API.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderColUsername { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderCollegeName { get; set; }
        public string SenderHsName { get; set; }

        public string SenderColUserType { get; set; }

        public ColUser Sender { get; set; }
        public int RecipientId { get; set; }
        public string RecipientColUsername { get; set; }
        public string RecipientFirstName { get; set; }
        public string RecipientCollegeName { get; set; }
        public string RecipientHsName { get; set; }

        public string RecipientColUserType { get; set; }

        public ColUser Recipient { get; set; }
        public string Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; } = DateTime.Now;
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }

    }
}