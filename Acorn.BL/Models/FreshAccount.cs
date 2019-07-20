using System;
using Acorn.BL.Helpers;

namespace Acorn.BL.Models
{
    public partial class FreshAccount
    {
        public long FreshAccountId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Regions Region { get; set; }
    }
}
