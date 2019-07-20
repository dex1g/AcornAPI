using System;
using System.Collections.Generic;
using Acorn.BL.Helpers;

namespace Acorn.BL.Models
{
    public partial class Account
    {
        public long AccountId { get; set; }
        public long BotId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Regions Region { get; set; }
        public int Level { get; set; }
        public int ExpPercentage { get; set; }

        public virtual Bot Bot { get; set; }
    }
}
