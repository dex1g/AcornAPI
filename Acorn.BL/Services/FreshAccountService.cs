using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acorn.BL.Models;
using Acorn.BL.RepositoriesInterfaces;
using Acorn.BL.Validators;

namespace Acorn.BL.Services
{
    public class FreshAccountService : IFreshAccountService
    {
        private readonly IFreshAccountsRepository _freshAccountsRepository;

        public FreshAccountService(IFreshAccountsRepository freshAccountsRepository)
        {
            _freshAccountsRepository = freshAccountsRepository;
        }

        public async Task<FreshAccount> CreateNewFreshAccountAsync(FreshAccount freshAccount)
        {
            if (!AccountValidator.ValidateDefault(freshAccount))
            {
                throw new InvalidOperationException(Resources.FreshAccValidFailString);
            }

            return await _freshAccountsRepository.AddFreshAccountAsync(freshAccount);
        }

        public async Task DeleteFreshAccountAsync(long freshAccountId)
        {
            await _freshAccountsRepository.DeleteFreshAccountAsync(freshAccountId);
        }

        public async Task<IEnumerable<FreshAccount>> GetAllFreshAccountsAsync()
        {
            return await _freshAccountsRepository.GetAllAsync();
        }

        public async Task<FreshAccount> GetFreshAccountByIdAsync(long freshAccountId)
        {
            return await _freshAccountsRepository.GetFreshAccountByIdAsync(freshAccountId);
        }

        public async Task UpdateFreshAccountAsync(FreshAccount freshAccount)
        {
            if (!AccountValidator.ValidateDefault(freshAccount))
            {
                throw new InvalidOperationException(Resources.FreshAccValidFailString);
            }

            await _freshAccountsRepository.UpdateFreshAccountAsync(freshAccount);
        }
    }
}
