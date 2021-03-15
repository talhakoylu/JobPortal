using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<List<Company>> GetAll();
        Task<IDataResult<List<Company>>> GetAllAsync();
        IDataResult<Company> GetById(int id);
        Task<IDataResult<Company>> GetByIdAsync(int id);
        IDataResult<List<Company>> GetAllByUserId(int id);
        Task<IDataResult<List<Company>>> GetAllByUserIdAsync(int id);

        IResult Add(Company company);
        Task<IResult> AddAsync(Company company);
        IResult Delete(Company company);
        Task<IResult> DeleteAsync(Company company);
        IResult Update(Company company);
        Task<IResult> UpdateAsync(Company company);

    }
}
