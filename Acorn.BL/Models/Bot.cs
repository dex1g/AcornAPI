using System.Collections.Generic;
using Acorn.BL.Enums;

namespace Acorn.BL.Models
{
    public partial class Bot
    {
        public Bot()
        {
            Accounts = new HashSet<Account>();
            Logs = new HashSet<Log>();
        }

        public int BotId { get; set; }
        public BotOrders BotOrder { get; set; }
        public virtual Config Config { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}
