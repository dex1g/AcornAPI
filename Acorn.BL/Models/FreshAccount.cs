using System;
using System.Collections.Generic;

namespace Acorn.BL.Models
{
    public partial class FreshAccount
    {
        public long FreshAccId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string BirthDate { get; set; }
    }
}
