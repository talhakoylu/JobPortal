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
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            var result = _userOperationClaimDal.GetAll();
            return new SuccessDataResult<List<UserOperationClaim>>(result, Messages.UserOperationClaim.GetAllSuccess);
        }

        public async Task<IDataResult<List<UserOperationClaim>>> GetAllAsync()
        {
            var result = await _userOperationClaimDal.GetAllAsync();
            return new SuccessDataResult<List<UserOperationClaim>>(result, Messages.UserOperationClaim.GetAllSuccess);
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            var result = _userOperationClaimDal.Get(uoc => uoc.Id == id);
            return new SuccessDataResult<UserOperationClaim>(result, Messages.UserOperationClaim.GetByIdSuccess);
        }

        public async Task<IDataResult<UserOperationClaim>> GetByIdAsync(int id)
        {
            var result = await _userOperationClaimDal.GetAsync(uoc => uoc.Id == id);
            return new SuccessDataResult<UserOperationClaim>(result, Messages.UserOperationClaim.GetByIdSuccess);
        }

        public IDataResult<List<UserOperationClaim>> GetAllByUserId(int id)
        {
            var result = _userOperationClaimDal.GetAll(uoc => uoc.UserId == id);
            return new SuccessDataResult<List<UserOperationClaim>>(result,
                Messages.UserOperationClaim.GetAllByUserIdSuccess);
        }

        public async Task<IDataResult<List<UserOperationClaim>>> GetAllByUserIdAsync(int id)
        {
            var result = await _userOperationClaimDal.GetAllAsync(uoc => uoc.UserId == id);
            return new SuccessDataResult<List<UserOperationClaim>>(result,
                Messages.UserOperationClaim.GetAllByUserIdSuccess);
        }

        public IDataResult<List<UserOperationClaim>> GetAllByOperationClaimId(int id)
        {
            var result = _userOperationClaimDal.GetAll(uoc => uoc.OperationClaimId == id);
            return new SuccessDataResult<List<UserOperationClaim>>(result,
                Messages.UserOperationClaim.GetAllByOperationClaimIdSuccess);
        }

        public async Task<IDataResult<List<UserOperationClaim>>> GetAllByOperationClaimIdAsync(int id)
        {
            var result = await _userOperationClaimDal.GetAllAsync(uoc => uoc.OperationClaimId == id);
            return new SuccessDataResult<List<UserOperationClaim>>(result,
                Messages.UserOperationClaim.GetAllByOperationClaimIdSuccess);
        }

        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaim.AddSuccess);
        }

        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public async Task<IResult> AddAsync(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimDal.AddAsync(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaim.AddSuccess);
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaim.DeleteSuccess);
        }

        public async Task<IResult> DeleteAsync(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimDal.DeleteAsync(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaim.DeleteSuccess);
        }

        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaim.UpdateSuccess);
        }

        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public async Task<IResult> UpdateAsync(UserOperationClaim userOperationClaim)
        {
            await _userOperationClaimDal.UpdateAsync(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaim.UpdateSuccess);
        }
    }
}
