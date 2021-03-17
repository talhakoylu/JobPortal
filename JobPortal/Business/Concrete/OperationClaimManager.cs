using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            var result = _operationClaimDal.GetAll();
            return new SuccessDataResult<List<OperationClaim>>(result, Messages.OperationClaim.GetAllSuccess);
        }

        public async Task<IDataResult<List<OperationClaim>>> GetAllAsync()
        {
            var result = await _operationClaimDal.GetAllAsync();
            return new SuccessDataResult<List<OperationClaim>>(result, Messages.OperationClaim.GetAllSuccess);
        }

        public IDataResult<OperationClaim> GetById(int id)
        {
            var result = _operationClaimDal.Get(op => op.Id == id);
            return new SuccessDataResult<OperationClaim>(result, Messages.OperationClaim.GetByIdSuccess);
        }

        public async Task<IDataResult<OperationClaim>> GetByIdAsync(int id)
        {
            var result = await _operationClaimDal.GetAsync(op => op.Id == id);
            return new SuccessDataResult<OperationClaim>(result, Messages.OperationClaim.GetByIdSuccess);
        }

        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaim.AddSuccess);
        }

        [ValidationAspect(typeof(OperationClaimValidator))]
        public async Task<IResult> AddAsync(OperationClaim operationClaim)
        {
            await _operationClaimDal.AddAsync(operationClaim);
            return new SuccessResult(Messages.OperationClaim.AddSuccess);
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.OperationClaim.DeleteSuccess);
        }

        public async Task<IResult> DeleteAsync(OperationClaim operationClaim)
        {
            await _operationClaimDal.DeleteAsync(operationClaim);
            return new SuccessResult(Messages.OperationClaim.DeleteSuccess);
        }

        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Update(OperationClaim operationClaim)
        {
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.OperationClaim.UpdateSuccess);
        }

        [ValidationAspect(typeof(OperationClaimValidator))]
        public async Task<IResult> UpdateAsync(OperationClaim operationClaim)
        {
            await _operationClaimDal.UpdateAsync(operationClaim);
            return new SuccessResult(Messages.OperationClaim.UpdateSuccess);
        }
    }
}
