using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private static DateTime[] _invalidBirthDateTestData =
        {
            new DateTime(2020,4,12),
            new DateTime(2019,12,3),
        };


        [Test]
        public async Task CreateNewAccountAsync_ValidData_NewAccountIsAdded()
        {
            // Arrange

            var mockAccountRepository = new Mock<IAccountsRepository>();

            var accountService = new AccountService(mockAccountRepository.Object);

            var account = new Account()
            {
                AccountId = 15,
                ExpPercentage = 56,
                Level = 15,
                Password = "TestMe",
                Login = "MyLogin",
                BirthDate = new DateTime(1996, 2, 14)
            };

            // Action

            await accountService.CreateNewAccountAsync(account);

            // Assert
            mockAccountRepository.Verify(m => m.AddAccountAsync(account), Times.Once);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateNewAccountAsync_InvalidLogin_NewAccountIsNotCreated_and_ExceptionIsRaised(string login)
        {
            // Arrange

            var mockAccountRepository = new Mock<IAccountsRepository>();

            var accountService = new AccountService(mockAccountRepository.Object);

            var account = new Account()
            {
                AccountId = 15,
                ExpPercentage = 56,
                Level = 15,
                Password = "TestMe",
                Login = login,
                BirthDate = new DateTime(1996, 2, 14)
            };

            // Action & Assert

            Assert.ThrowsAsync<InvalidOperationException>(() => accountService.CreateNewAccountAsync(account));

        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateNewAccountAsync_InvalidPassword_NewAccountIsNotCreated_and_ExceptionIsRaised(string password)
        {
            // Arrange

            var mockAccountRepository = new Mock<IAccountsRepository>();

            var accountService = new AccountService(mockAccountRepository.Object);

            var account = new Account()
            {
                AccountId = 15,
                ExpPercentage = 56,
                Level = 15,
                Password = password,
                Login = "Test",
                BirthDate = new DateTime(1996, 2, 14)
            };

            // Action & Assert

            Assert.ThrowsAsync<InvalidOperationException>(() => accountService.CreateNewAccountAsync(account));

        }

        [Test, TestCaseSource(nameof(_invalidBirthDateTestData))]
        public void CreateNewAccountAsync_InvalidBirthDate_NewAccountIsNotCreated_and_ExceptionIsRaised(DateTime birthDate)
        {
            // Arrange

            var mockAccountRepository = new Mock<IAccountsRepository>();

            var accountService = new AccountService(mockAccountRepository.Object);

            var account = new Account()
            {
                AccountId = 15,
                ExpPercentage = 56,
                Level = 15,
                Password = "Test",
                Login = "Test",
                BirthDate = birthDate
            };

            // Action & Assert

            Assert.ThrowsAsync<InvalidOperationException>(() => accountService.CreateNewAccountAsync(account));

        }

        [Test]
        public async Task UpdateAccountAsync_AccountExistsInDatabase_ValidDataForUpdate_AccountIsUpdated()
        {
            // Arrange

            var account = new Account()
            {
                AccountId = 13,
                ExpPercentage = 56,
                Level = 15,
                Password = "TestMe",
                Login = "MyLogin",
                BirthDate = new DateTime(1996, 2, 14)
            };

            var mockAccountRepository = new Mock<IAccountsRepository>();

            mockAccountRepository.Setup(m => m.GetAccountByIdAsync(It.IsAny<int>())).ReturnsAsync(account);

            mockAccountRepository.Setup(m => m.UpdateAccountAsync(It.IsAny<Account>())).Callback(() => account.AccountId = 100);

            var accountService = new AccountService(mockAccountRepository.Object);


            // Action

            await accountService.UpdateAccountAsync(account);

            // Assert
            mockAccountRepository.Verify(m => m.UpdateAccountAsync(account), Times.Once);

            Assert.AreEqual(100, account.AccountId);
        }
    }
}