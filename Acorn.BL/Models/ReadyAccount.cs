using System;
using Acorn.BL.Enums;
using Acorn.BL.Helpers;
using Newtonsoft.Json;

namespace Acorn.BL.Models
{
    public partial class ReadyAccount
    {
        [JsonProperty(PropertyName = "accountId")]
        public long ReadyAccountId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [JsonConverter(typeof(DateConverter))]
        public DateTime BirthDate { get; set; }
        public Region Region { get; set; }
    }
}
