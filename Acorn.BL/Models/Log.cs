using System;
using System.Collections.Generic;

namespace Acorn.BL.Models
{
    public partial class Log
    {
        public long LogId { get; set; }
        public long BotId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public virtual Bot Bot { get; set; }
    }
}
