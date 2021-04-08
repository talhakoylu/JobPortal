using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

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

        IResult Add(CurriculumVitae cv, IFormFile file);
        Task<IResult> AddAsync(CurriculumVitae cv, IFormFile file);
        IResult DeleteSoft(CurriculumVitae cv);
        IResult DeleteHard(CurriculumVitae cv);
        Task<IResult> DeleteHardAsync(CurriculumVitae cv);
        IResult Update(CurriculumVitae cv, IFormFile file);
        Task<IResult> UpdateAsync(CurriculumVitae cv, IFormFile file);
    }
}
