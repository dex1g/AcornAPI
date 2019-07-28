using System;
using Acorn.BL.Enums;

namespace Acorn.BL.Models
{
    public partial class ReadyAccount
    {
        public long ReadyAccountId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Region Region { get; set; }
    }
}
