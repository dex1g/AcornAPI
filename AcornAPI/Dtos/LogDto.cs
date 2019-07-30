using System;

namespace AcornAPI.Dtos
{
    public class LogDto
    {
        public long LogId { get; set; }
        public int BotId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
