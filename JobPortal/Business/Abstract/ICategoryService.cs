using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        Task<IDataResult<List<Category>>> GetAllAsync();
        IDataResult<Category> GetById(int id);
        Task<IDataResult<Category>> GetByIdAsync(int id);

        IResult Add(Category category);
        Task<IResult> AddAsync(Category category);
        IResult Delete(Category category);
        Task<IResult> DeleteAsync(Category category);
        IResult Update(Category category);
        Task<IResult> UpdateAsync(Category category);
    }
}
