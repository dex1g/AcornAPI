using System;
using System.Collections.Generic;

namespace Acorn.BL.Models
{
    public partial class Bot
    {
        public Bot()
        {
            Logs = new HashSet<Log>();
        }

        public long BotId { get; set; }
        public string Nick { get; set; }
        public byte[] Level { get; set; }

        public virtual Account Account { get; set; }
        public virtual BotOrder BotOrder { get; set; }
        public virtual Config Config { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
