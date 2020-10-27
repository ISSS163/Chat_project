using System;

namespace Server
{
    public class DialogInfo
    {
        public Guid DialogId { get; set; }
        public UserInfo User { get; set; }
        public string LastMessage { get; set; } 
        public DateTime SendTimeLastM { get; set; }
        //TODO
    }
}