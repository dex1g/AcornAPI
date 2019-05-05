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
        public string OverwriteConfig { get; set; }
        public string Champion1 { get; set; }
        public string Champion2 { get; set; }
        public string Champion3 { get; set; }
        public string Champion4 { get; set; }
        public string Champion5 { get; set; }

        public virtual Bot Bot { get; set; }
    }
}
