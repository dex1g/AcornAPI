using System;
using Acorn.BL.Enums;
using Acorn.BL.Helpers;
using Newtonsoft.Json;

namespace AcornAPI.Dtos
{
    public class AccountDto
    {
        public long AccountId { get; set; }
        public int BotId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [JsonConverter(typeof(DateConverter))]
        public DateTime BirthDate { get; set; }
        public Region Region { get; set; }
        public int Level { get; set; }
        public int ExpPercentage { get; set; }
    }
}
