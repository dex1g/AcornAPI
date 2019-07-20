using Acorn.BL.Helpers;

namespace Acorn.BL.Models
{
    public partial class Config
    {
        public int BotId { get; set; }
        public QueueTypes QueueType { get; set; }
        public AiConfigs AiConfig { get; set; }
        public string Path { get; set; }
        public bool? OverwriteConfig { get; set; }
        public bool? CloseBrowser { get; set; }
        public int NoActionTimeout { get; set; }

        public virtual Bot Bot { get; set; }
    }
}
