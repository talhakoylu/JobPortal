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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.Category.GetAllSuccess);

        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            var result = await _categoryDal.GetAllAsync();
            return new SuccessDataResult<List<Category>>(result, Messages.Category.GetAllSuccess);
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDal.Get(c => c.Id == id);
            return new SuccessDataResult<Category>(result, Messages.Category.GetByIdSuccess);
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            var result = await _categoryDal.GetAsync(c => c.Id == id);
            return new SuccessDataResult<Category>(result, Messages.Category.GetByIdSuccess);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.Category.AddSuccess);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IResult> AddAsync(Category category)
        {
            await _categoryDal.AddAsync(category);
            return new SuccessResult(Messages.Category.AddSuccess);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.Category.DeleteSuccess);
        }

        public async Task<IResult> DeleteAsync(Category category)
        {
            await _categoryDal.DeleteAsync(category);
            return new SuccessResult(Messages.Category.DeleteSuccess);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Category.UpdateSuccess);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public async Task<IResult> UpdateAsync(Category category)
        {
            await _categoryDal.UpdateAsync(category);
            return new SuccessResult(Messages.Category.UpdateSuccess);
        }
    }
}
