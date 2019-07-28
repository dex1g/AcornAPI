using System;
using System.Collections.Generic;
using Acorn.BL.Enums;
using Acorn.BL.Models;

namespace Acorn.DAL
{
    public class SeedDatabase
    {
        private readonly DatabaseContext _context;

        public SeedDatabase(DatabaseContext context)
        {
            _context = context;
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public void Seed()
        {
            var bot1 = new Bot()
            {
                BotId = 1,
                Config = new Config()
            };

            var bot2 = new Bot()
            {
                BotId = 2,
                Config = new Config() { OverwriteConfig = false, NoActionTimeout = 1200 },
                BotOrder = BotOrder.Start
            };

            _context.Bots.Add(bot1);
            _context.Bots.Add(bot2);
            _context.SaveChanges();

            var account1 = new Account()
            {
                Bot = bot1,
                Login = "maciek76",
                Password = "qwertz21",
                BirthDate = new DateTime(1994, 11, 13),
                Region = Region.Eune,
                Level = 12,
                ExpPercentage = 57
            };

            var account2 = new Account()
            {
                Bot = bot1,
                Login = "przemo24",
                Password = "asdf54",
                BirthDate = new DateTime(1999, 4, 23),
                Region = Region.Eune,
                Level = 26,
                ExpPercentage = 7
            };

            var account3 = new Account()
            {
                Bot = bot2,
                Login = "cycu547",
                Password = "dupa123",
                BirthDate = new DateTime(1997, 7, 28),
                Region = Region.Euw,
                Level = 18,
                ExpPercentage = 84
            };

            _context.Accounts.Add(account1);
            _context.Accounts.Add(account2);
            _context.Accounts.Add(account3);
            _context.SaveChanges();

            var freshAcc1 = new FreshAccount()
            {
                Login = "burek12",
                Password = "fsd54yf",
                BirthDate = new DateTime(1997, 12, 21),
                Region = Region.Euw,
            };

            var freshAcc2 = new FreshAccount()
            {
                Login = "manio764",
                Password = "mrn56i9f",
                BirthDate = new DateTime(1994, 4, 3),
                Region = Region.Eune,
            };

            var freshAcc3 = new FreshAccount()
            {
                Login = "suhy666",
                Password = "raz2trzy",
                BirthDate = new DateTime(1998, 11, 6),
                Region = Region.Na,
            };

            var freshAcc4 = new FreshAccount()
            {
                Login = "malaszmula",
                Password = "krol69lew",
                BirthDate = new DateTime(1992, 5, 18),
                Region = Region.Eune,
            };

            _context.FreshAccounts.Add(freshAcc1);
            _context.FreshAccounts.Add(freshAcc2);
            _context.FreshAccounts.Add(freshAcc3);
            _context.FreshAccounts.Add(freshAcc4);
            _context.SaveChanges();

            var rdyAcc1 = new ReadyAccount()
            {
                Login = "muli55",
                Password = "bxcv3567",
                BirthDate = new DateTime(1995, 11, 22),
                Region = Region.Eune,
            };

            var rdyAcc2 = new ReadyAccount()
            {
                Login = "maju44",
                Password = "44pamietamy",
                BirthDate = new DateTime(1997, 4, 20),
                Region = Region.Eune,
            };

            var rdyAcc3 = new ReadyAccount()
            {
                Login = "zielasz420",
                Password = "bl4zeit20",
                BirthDate = new DateTime(1995, 2, 21),
                Region = Region.Euw,
            };

            var rdyAcc4 = new ReadyAccount()
            {
                Login = "qbapvpking",
                Password = "64cobble",
                BirthDate = new DateTime(1991, 2, 12),
                Region = Region.Eune,
            };

            _context.ReadyAccounts.Add(rdyAcc1);
            _context.ReadyAccounts.Add(rdyAcc2);
            _context.ReadyAccounts.Add(rdyAcc3);
            _context.ReadyAccounts.Add(rdyAcc4);
            _context.SaveChanges();

            var log1 = new Log()
            {
                Bot = bot1,
                Date = new DateTime(2019, 07, 20, 15, 20, 34),
                Status = "Launching league"
            };

            var log2 = new Log()
            {
                Bot = bot1,
                Date = new DateTime(2019, 07, 20, 15, 20, 50),
                Status = "Logging in"
            };

            var log3 = new Log()
            {
                Bot = bot1,
                Date = new DateTime(2019, 07, 20, 15, 21, 03),
                Status = "Queueing up"
            };

            var log4 = new Log()
            {
                Bot = bot1,
                Date = new DateTime(2019, 07, 20, 15, 22, 26),
                Status = "Picking champion"
            };

            var log5 = new Log()
            {
                Bot = bot1,
                Date = new DateTime(2019, 07, 20, 15, 24, 11),
                Status = "Starting game script"
            };

            var log6 = new Log()
            {
                Bot = bot2,
                Date = new DateTime(2019, 07, 20, 17, 06, 15),
                Status = "Active game detected"
            };

            var log7 = new Log()
            {
                Bot = bot2,
                Date = new DateTime(2019, 07, 20, 17, 06, 34),
                Status = "Launching script"
            };

            var log8 = new Log()
            {
                Bot = bot2,
                Date = new DateTime(2019, 07, 20, 17, 08, 28),
                Status = "Enemy champion detected"
            };

            var log9 = new Log()
            {
                Bot = bot2,
                Date = new DateTime(2019, 07, 20, 17, 09, 44),
                Status = "Bot is low hp. Recalling..."
            };

            var logList = new List<Log>() { log1, log2, log3, log4, log5, log6, log7, log8, log9 };

            foreach (var log in logList)
            {
                _context.Logs.Add(log);
            }
            _context.SaveChanges();
        }
    }

}
