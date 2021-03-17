using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public IDataResult<List<Company>> GetAll()
        {
            var result = _companyDal.GetAll();
            return new SuccessDataResult<List<Company>>(result, Messages.Company.GetAllSuccess);
        }

        public async Task<IDataResult<List<Company>>> GetAllAsync()
        {
            var result = await _companyDal.GetAllAsync();
            return new SuccessDataResult<List<Company>>(result, Messages.Company.GetAllSuccess);
        }

        public IDataResult<Company> GetById(int id)
        {
            var result = _companyDal.Get(c => c.Id == id);
            return new SuccessDataResult<Company>(result, Messages.Company.GetByIdSuccess);
        }

        public async Task<IDataResult<Company>> GetByIdAsync(int id)
        {
            var result = await _companyDal.GetAsync(c => c.Id == id);
            return new SuccessDataResult<Company>(result, Messages.Company.GetByIdSuccess);
        }

        public IDataResult<List<Company>> GetAllByUserId(int id)
        {
            var result = _companyDal.GetAll(c => c.UserId == id);
            return new SuccessDataResult<List<Company>>(result, Messages.Company.GetAllByUserIdSuccess);
        }

        public async Task<IDataResult<List<Company>>> GetAllByUserIdAsync(int id)
        {
            var result = await _companyDal.GetAllAsync(c => c.UserId == id);
            return new SuccessDataResult<List<Company>>(result, Messages.Company.GetAllByUserIdSuccess);
        }

        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult(Messages.Company.AddSuccess);
        }

        [ValidationAspect(typeof(CompanyValidator))]
        public async Task<IResult> AddAsync(Company company)
        {
            await _companyDal.AddAsync(company);
            return new SuccessResult(Messages.Company.AddSuccess);
        }

        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);
            return new SuccessResult(Messages.Company.DeleteSuccess);
        }

        public async Task<IResult> DeleteAsync(Company company)
        {
            await _companyDal.DeleteAsync(company);
            return new SuccessResult(Messages.Company.DeleteSuccess);
        }

        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult(Messages.Company.UpdateSuccess);
        }

        [ValidationAspect(typeof(CompanyValidator))]
        public async Task<IResult> UpdateAsync(Company company)
        {
            await _companyDal.UpdateAsync(company);
            return new SuccessResult(Messages.Company.UpdateSuccess);
        }
    }
}
