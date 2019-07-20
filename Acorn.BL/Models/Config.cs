using System;
using System.Collections.Generic;

namespace Acorn.BL.Models
{
    public partial class Config
    {
        public long BotId { get; set; }
        public string Queuetype { get; set; }
        public string Aiconfig { get; set; }
        public string Path { get; set; }
        public bool OverwriteConfig { get; set; }
        public bool CloseBrowser { get; set; }
        public int NoActionTimeout { get; set; }

        public virtual Bot Bot { get; set; }
    }
}
