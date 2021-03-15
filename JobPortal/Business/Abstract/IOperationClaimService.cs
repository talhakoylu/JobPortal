using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<List<OperationClaim>> GetAll();
        Task<IDataResult<List<OperationClaim>>> GetAllAsync();
        IDataResult<OperationClaim> GetById(int id);
        Task<IDataResult<OperationClaim>> GetByIdAsync(int id);

        IResult Add(OperationClaim operationClaim);
        Task<IResult> AddAsync(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);
        Task<IResult> DeleteAsync(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        Task<IResult> UpdateAsync(OperationClaim operationClaim);
    }
}
