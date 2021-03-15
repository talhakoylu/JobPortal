using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetAll();
        Task<IDataResult<List<UserOperationClaim>>> GetAllAsync();
        IDataResult<UserOperationClaim> GetById(int id);
        Task<IDataResult<UserOperationClaim>> GetByIdAsync(int id);
        IDataResult<List<UserOperationClaim>> GetAllByUserId(int id);
        Task<IDataResult<List<UserOperationClaim>>> GetAllByUserIdAsync(int id);
        IDataResult<List<UserOperationClaim>> GetAllByOperationClaimId(int id);
        Task<IDataResult<List<UserOperationClaim>>> GetAllByOperationClaimIdAsync(int id);

        IResult Add(UserOperationClaim userOperationClaim);
        Task<IResult> AddAsync(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);
        Task<IResult> DeleteAsync(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
        Task<IResult> UpdateAsync(UserOperationClaim userOperationClaim);
    }
}
