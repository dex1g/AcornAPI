using System;
using System.Collections.Generic;
using Acorn.BL.Helpers;

namespace Acorn.BL.Models
{
    public partial class FreshAccount
    {
        public long FreshAccId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Regions Region { get; set; }
        public string BirthDate { get; set; }
    }
}
