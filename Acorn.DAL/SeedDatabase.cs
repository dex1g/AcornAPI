using System;
using System.Collections.Generic;
using Acorn.BL.Helpers;
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
                Order = BotOrders.Start
            };

            _context.Bots.Add(bot1);
            _context.Bots.Add(bot2);
            _context.SaveChanges();

            var account1 = new Account()
            {
                Bot = bot1,
                Login = "maciek76",
                Password = "qwertz21",
                BirthDate = "13/11/1994",
                Region = Regions.Eune,
                Level = 12,
                ExpPercentage = 57
            };

            var account2 = new Account()
            {
                Bot = bot1,
                Login = "przemo24",
                Password = "asdf54",
                BirthDate = "24/04/1999",
                Region = Regions.Eune,
                Level = 26,
                ExpPercentage = 7
            };

            var account3 = new Account()
            {
                Bot = bot2,
                Login = "cycu547",
                Password = "dupa123",
                BirthDate = "28/07/1997",
                Region = Regions.Euw,
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
                BirthDate = "21/12/1997",
                Region = Regions.Euw,
            };

            var freshAcc2 = new FreshAccount()
            {
                Login = "manio764",
                Password = "mrn56i9f",
                BirthDate = "03/04/1994",
                Region = Regions.Eune,
            };

            var freshAcc3 = new FreshAccount()
            {
                Login = "suhy666",
                Password = "raz2trzy",
                BirthDate = "11/06/1998",
                Region = Regions.Na,
            };

            var freshAcc4 = new FreshAccount()
            {
                Login = "malaszmula",
                Password = "krol69lew",
                BirthDate = "18/05/1992",
                Region = Regions.Eune,
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
                BirthDate = "11/12/1995",
                Region = Regions.Eune,
            };

            var rdyAcc2 = new ReadyAccount()
            {
                Login = "maju44",
                Password = "44pamietamy",
                BirthDate = "20/04/1997",
                Region = Regions.Eune,
            };

            var rdyAcc3 = new ReadyAccount()
            {
                Login = "zielasz420",
                Password = "bl4zeit20",
                BirthDate = "11/02/1995",
                Region = Regions.Euw,
            };

            var rdyAcc4 = new ReadyAccount()
            {
                Login = "qbapvpking",
                Password = "64cobble",
                BirthDate = "26/10/1991",
                Region = Regions.Eune,
            };

            _context.ReadyAccounts.Add(rdyAcc1);
            _context.ReadyAccounts.Add(rdyAcc2);
            _context.ReadyAccounts.Add(rdyAcc3);
            _context.ReadyAccounts.Add(rdyAcc4);
            _context.SaveChanges();

            var log1 = new Log()
            {
                Bot = bot1,
                Date = new DateTime(2019, 07, 20, 15, 20, 34).ToString("dd-MM-yyyy HH-mm-ss"),
                Status = "Launching league"
            };

            var log2 = new Log()
            {
                Bot = bot1,
                Date = new DateTime(2019, 07, 20, 15, 20, 50).ToString("dd-MM-yyyy HH-mm-ss"),
                Status = "Logging in"
            };

            var log3 = new Log()
            {
                Bot = bot1,
                Date = new DateTime(2019, 07, 20, 15, 21, 03).ToString("dd-MM-yyyy HH-mm-ss"),
                Status = "Queueing up"
            };

            var log4 = new Log()
            {
                Bot = bot1,
                Date = new DateTime(2019, 07, 20, 15, 22, 26).ToString("dd-MM-yyyy HH-mm-ss"),
                Status = "Picking champion"
            };

            var log5 = new Log()
            {
                Bot = bot1,
                Date = new DateTime(2019, 07, 20, 15, 24, 11).ToString("dd-MM-yyyy HH-mm-ss"),
                Status = "Starting game script"
            };

            var log6 = new Log()
            {
                Bot = bot2,
                Date = new DateTime(2019, 07, 20, 17, 06, 15).ToString("dd-MM-yyyy HH-mm-ss"),
                Status = "Active game detected"
            };

            var log7 = new Log()
            {
                Bot = bot2,
                Date = new DateTime(2019, 07, 20, 17, 06, 34).ToString("dd-MM-yyyy HH-mm-ss"),
                Status = "Launching script"
            };

            var log8 = new Log()
            {
                Bot = bot2,
                Date = new DateTime(2019, 07, 20, 17, 08, 28).ToString("dd-MM-yyyy HH-mm-ss"),
                Status = "Enemy champion detected"
            };

            var log9 = new Log()
            {
                Bot = bot2,
                Date = new DateTime(2019, 07, 20, 17, 09, 44).ToString("dd-MM-yyyy HH-mm-ss"),
                Status = "Bot is low hp. Recalling..."
            };

            var logList = new List<Log>() { log1, log2, log3, log4, log5, log6, log7, log8, log9 };

            foreach (var log in logList)
            {
                _context.Logs.Add(log);
            }
            _context.SaveChangesAsync();
        }
    }

}
