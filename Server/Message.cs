using System;

namespace Server
{
    public class Message
    {
        //TODO
        public Guid MessageId { get; set; }
        public Guid SenderId { get; set; }
        public Guid DialogId { get; set; }
        public string SenderUserName { get; set; }
        public string MessageText { get; set; } 
        public DateTime SendTime { get; set; }
    }
}