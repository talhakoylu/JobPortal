using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAdvertisementService
    {
        IDataResult<List<Advertisement>> GetAll();
        Task<IDataResult<List<Advertisement>>> GetAllAsync();
        IDataResult<Advertisement> GetById(int id);
        Task<IDataResult<Advertisement>> GetByIdAsync(int id);
        IDataResult<List<Advertisement>> GetByCompanyId(int id);
        Task<IDataResult<List<Advertisement>>> GetByCompanyIdAsync(int id);
        IDataResult<List<Advertisement>> GetByCategoryId(int id);
        Task<IDataResult<List<Advertisement>>> GetByCategoryIdAsync(int id);

        IResult Add(Advertisement advertisement);
        Task<IResult> AddAsync(Advertisement advertisement);
        IResult Delete(Advertisement advertisement);
        Task<IResult> DeleteAsync(Advertisement advertisement);
        IResult Update(Advertisement advertisement);
        Task<IResult> UpdateAsync(Advertisement advertisement);
    } 
}
