using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acorn.BL.Enums;

namespace AcornAPI.Dtos
{
    public class ConfigDto
    {
        public int BotId { get; set; }
        public QueueTypes QueueType { get; set; }
        public AiConfigs AiConfig { get; set; }
        public string Path { get; set; }
        public bool? OverwriteConfig { get; set; }
        public bool? CloseBrowser { get; set; }
        public int NoActionTimeout { get; set; }
    }
}
