using System;
using System.Collections.Generic;
using Acorn.BL.Helpers;

namespace Acorn.BL.Models
{
    public partial class Bot
    {
        public Bot()
        {
            Logs = new HashSet<Log>();
        }

        public long BotId { get; set; }
        public BotOrders Order { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual Config Config { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
