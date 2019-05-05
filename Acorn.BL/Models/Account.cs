using System;
using System.Collections.Generic;

namespace Acorn.BL.Models
{
    public partial class Account
    {
        public long BotId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string BirthDate { get; set; }

        public virtual Bot Bot { get; set; }
    }
}
