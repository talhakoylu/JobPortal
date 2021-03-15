using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants.Messages;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result, Messages.User.GetAllSuccess);
        }

        public async Task<IDataResult<List<User>>> GetAllAsync()
        {
            var result = await _userDal.GetAllAsync();
            return new SuccessDataResult<List<User>>(result, Messages.User.GetAllSuccess);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            return new SuccessDataResult<User>(result, Messages.User.GetByIdSuccess);
        }

        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            var result = await _userDal.GetAsync(u => u.Id == id);
            return new SuccessDataResult<User>(result, Messages.User.GetByIdSuccess);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result, Messages.User.GetByMailSuccess);
        }

        public async Task<IDataResult<User>> GetByMailAsync(string email)
        {
            var result = await _userDal.GetAsync(u => u.Email == email);
            return new SuccessDataResult<User>(result, Messages.User.GetByMailSuccess);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.User.AddSuccess);
        }

        public async Task<IResult> AddAsync(User user)
        {
            await _userDal.AddAsync(user);
            return new SuccessResult(Messages.User.AddSuccess);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.User.DeleteSuccess);
        }

        public async Task<IResult> DeleteAsync(User user)
        {
            await _userDal.DeleteAsync(user);
            return new SuccessResult(Messages.User.DeleteSuccess);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.User.UpdateSuccess);
        }

        public async Task<IResult> UpdateAsync(User user)
        {
            await _userDal.UpdateAsync(user);
            return new SuccessResult(Messages.User.UpdateSuccess);
        }
    }
}
