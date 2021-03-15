using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICurriculumVitaeService
    {
        IDataResult<List<CurriculumVitae>> GetAll();
        Task<IDataResult<List<CurriculumVitae>>> GetAllAsync();
        IDataResult<CurriculumVitae> GetById(int id);
        Task<IDataResult<CurriculumVitae>> GetByIdAsync(int id);
        IDataResult<List<CurriculumVitae>> GetAllByUserId(int id);
        Task<IDataResult<List<CurriculumVitae>>> GetAllByUserIdAsync(int id);

        IResult Add(CurriculumVitae cv);
        Task<IResult> AddAsync(CurriculumVitae cv);
        IResult Delete(CurriculumVitae cv);
        Task<IResult> DeleteAsync(CurriculumVitae cv);
        IResult Update(CurriculumVitae cv);
        Task<IResult> UpdateAsync(CurriculumVitae cv);
    }
}
