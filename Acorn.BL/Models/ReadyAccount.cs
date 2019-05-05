using System;
using System.Collections.Generic;

namespace Acorn.BL.Models
{
    public partial class ReadyAccount
    {
        public long ReadyAccId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string BirthDate { get; set; }
    }
}
