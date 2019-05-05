using System;
using System.Collections.Generic;

namespace Acorn.BL.Models
{
    public partial class BotOrder
    {
        public long BotId { get; set; }
        public string Order { get; set; }

        public virtual Bot Bot { get; set; }
    }
}
