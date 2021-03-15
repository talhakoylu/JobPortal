using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        Task<IDataResult<List<User>>> GetAllAsync();
        IDataResult<User> GetById(int id);
        Task<IDataResult<User>> GetByIdAsync(int id);
        IDataResult<User> GetByMail(string email);
        Task<IDataResult<User>> GetByMailAsync(string email);

        IResult Add(User user);
        Task<IResult> AddAsync(User user);
        IResult Delete(User user);
        Task<IResult> DeleteAsync(User user);
        IResult Update(User user);
        Task<IResult> UpdateAsync(User user);
    }
}
