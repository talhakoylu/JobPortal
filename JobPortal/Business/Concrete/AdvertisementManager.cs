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
    public class AdvertisementManager : IAdvertisementService
    {
        private IAdvertisementDal _advertisementDal;

        public AdvertisementManager(IAdvertisementDal advertisementDal)
        {
            _advertisementDal = advertisementDal;
        }

        public IDataResult<List<Advertisement>> GetAll()
        {
            return new SuccessDataResult<List<Advertisement>>(_advertisementDal.GetAll(), Messages.Advertisement.GetAllSuccess);
        }

        public async Task<IDataResult<List<Advertisement>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Advertisement>>(await _advertisementDal.GetAllAsync(),
                Messages.Advertisement.GetAllSuccess);
        }

        public IDataResult<Advertisement> GetById(int id)
        {
            var result = _advertisementDal.Get(a => a.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Advertisement>(Messages.Advertisement.GetByIdErrorNull);
            }
            return new SuccessDataResult<Advertisement>(result, Messages.Advertisement.GetByIdSuccess);
        }

        public async Task<IDataResult<Advertisement>> GetByIdAsync(int id)
        {
            var result = await _advertisementDal.GetAsync(a => a.Id == id);
            return new SuccessDataResult<Advertisement>(result, Messages.Advertisement.GetByIdSuccess);
        }

        public IDataResult<List<Advertisement>> GetByCompanyId(int id)
        {
            var result = _advertisementDal.GetAll(a => a.CompanyId == id);
            return new SuccessDataResult<List<Advertisement>>(result, Messages.Advertisement.GetByCompanyIdSuccess);
        }

        public async Task<IDataResult<List<Advertisement>>> GetByCompanyIdAsync(int id)
        {
            var result = await _advertisementDal.GetAllAsync(a => a.CompanyId == id);
            return new SuccessDataResult<List<Advertisement>>(result, Messages.Advertisement.GetByCompanyIdSuccess);
        }

        public IDataResult<List<Advertisement>> GetByCategoryId(int id)
        {
            var result = _advertisementDal.GetAll(a => a.CategoryId == id);
            return new SuccessDataResult<List<Advertisement>>(result, Messages.Advertisement.GetByCategoryIdSuccess);
        }

        public async Task<IDataResult<List<Advertisement>>> GetByCategoryIdAsync(int id)
        {
            var result = await _advertisementDal.GetAllAsync(a => a.CategoryId == id);
            return new SuccessDataResult<List<Advertisement>>(result, Messages.Advertisement.GetByCategoryIdSuccess);
        }

        [ValidationAspect(typeof(AdvertisementValidator))]
        public IResult Add(Advertisement advertisement)
        {
            _advertisementDal.Add(advertisement);
            return new SuccessResult(Messages.Advertisement.AddSuccess);
        }

        [ValidationAspect(typeof(AdvertisementValidator))]
        public async Task<IResult> AddAsync(Advertisement advertisement)
        {
            await _advertisementDal.AddAsync(advertisement);
            return new SuccessResult(Messages.Advertisement.AddSuccess);
        }

        public IResult Delete(Advertisement advertisement)
        {
            _advertisementDal.Delete(advertisement);
            return new SuccessResult(Messages.Advertisement.DeleteSuccess);
        }

        public async Task<IResult> DeleteAsync(Advertisement advertisement)
        {
            await _advertisementDal.DeleteAsync(advertisement);
            return new SuccessResult(Messages.Advertisement.DeleteSuccess);
        }

        [ValidationAspect(typeof(AdvertisementValidator))]
        public IResult Update(Advertisement advertisement)
        {
            _advertisementDal.Update(advertisement);
            return new SuccessResult(Messages.Advertisement.UpdateSuccess);
        }

        [ValidationAspect(typeof(AdvertisementValidator))]
        public async Task<IResult> UpdateAsync(Advertisement advertisement)
        {
            await _advertisementDal.UpdateAsync(advertisement);
            return new SuccessResult(Messages.Advertisement.UpdateSuccess);
        }
    }
}
