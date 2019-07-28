using Acorn.BL.Enums;

namespace Acorn.BL.Models
{
    public partial class Config
    {
        public int BotId { get; set; }
        public QueueType QueueType { get; set; }
        public AiConfig AiConfig { get; set; }
        public string Path { get; set; }
        public bool? OverwriteConfig { get; set; }
        public bool? CloseBrowser { get; set; }
        public int NoActionTimeout { get; set; }

        public virtual Bot Bot { get; set; }
    }
}
