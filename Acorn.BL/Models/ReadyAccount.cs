using System;
using System.Collections.Generic;
using Acorn.BL.Helpers;

namespace Acorn.BL.Models
{
    public partial class ReadyAccount
    {
        public long ReadyAccountId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Regions Region { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
