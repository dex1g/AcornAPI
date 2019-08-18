using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Validators;

namespace Acorn.BL.Services
{
    public class ReadyAccountService : IReadyAccountService
    {
        private readonly IReadyAccountsRepository _readyAccountsRepository;

        public ReadyAccountService(IReadyAccountsRepository readyAccountsRepository)
        {
            _readyAccountsRepository = readyAccountsRepository;
        }

        public async Task<ReadyAccount> CreateNewReadyAccountAsync(ReadyAccount readyAccount)
        {
            if (!AccountValidator.ValidateDefault(readyAccount))
            {
                throw new InvalidOperationException(Resources.ReadyAccValidFail);
            }

            return await _readyAccountsRepository.AddReadyAccountAsync(readyAccount);
        }

        public async Task DeleteReadyAccountAsync(long readyAccountId)
        {
            await _readyAccountsRepository.DeleteReadyAccountAsync(readyAccountId);
        }

        public async Task<IEnumerable<ReadyAccount>> GetAllReadyAccountsAsync()
        {
            return await _readyAccountsRepository.GetAllAsync();
        }

        public async Task<ReadyAccount> GetReadyAccountByIdAsync(long readyAccountId)
        {
            return await _readyAccountsRepository.GetReadyAccountByIdAsync(readyAccountId);
        }

        public async Task UpdateReadyAccountAsync(ReadyAccount readyAccount)
        {
            if (!AccountValidator.ValidateDefault(readyAccount))
            {
                throw new InvalidOperationException(Resources.ReadyAccValidFail);
            }

            await _readyAccountsRepository.UpdateReadyAccountAsync(readyAccount);
        }
    }
}
