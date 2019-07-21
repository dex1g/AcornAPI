using System;
using Acorn.BL.Enums;

namespace AcornAPI.Dtos
{
    public class AccountDto
    {
        public long AccountId { get; set; }
        public int BotId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Regions Region { get; set; }
        public int Level { get; set; }
        public int ExpPercentage { get; set; }
    }
}
