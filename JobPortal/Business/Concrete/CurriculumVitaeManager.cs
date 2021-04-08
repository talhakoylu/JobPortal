using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CurriculumVitaeManager : ICurriculumVitaeService
    {
        private ICurriculumVitaeDal _curriculumVitaeDal;

        public CurriculumVitaeManager(ICurriculumVitaeDal curriculumVitaeDal)
        {
            _curriculumVitaeDal = curriculumVitaeDal;
        }

        public IDataResult<List<CurriculumVitae>> GetAll()
        {
            var result = _curriculumVitaeDal.GetAll();
            return new SuccessDataResult<List<CurriculumVitae>>(result,
                Messages.CurriculumVitae.GetAllSuccess);
        }

        public async Task<IDataResult<List<CurriculumVitae>>> GetAllAsync()
        {
            var result = await _curriculumVitaeDal.GetAllAsync();
            return new SuccessDataResult<List<CurriculumVitae>>(result,
                Messages.CurriculumVitae.GetAllSuccess);
        }

        public IDataResult<CurriculumVitae> GetById(int id)
        {
            var result = _curriculumVitaeDal.Get(cv => cv.Id == id);
            return new SuccessDataResult<CurriculumVitae>(result,
                Messages.CurriculumVitae.GetByIdSuccess);
        }

        public async Task<IDataResult<CurriculumVitae>> GetByIdAsync(int id)
        {
            var result = await _curriculumVitaeDal.GetAsync(cv => cv.Id == id);
            return new SuccessDataResult<CurriculumVitae>(result,
                Messages.CurriculumVitae.GetByIdSuccess);
        }

        public IDataResult<List<CurriculumVitae>> GetAllByUserId(int id)
        {
            var result = _curriculumVitaeDal.GetAll(cv => cv.UserId == id);
            return new SuccessDataResult<List<CurriculumVitae>>(result, Messages.CurriculumVitae.GetAllByUserIdSuccess);
        }

        public async Task<IDataResult<List<CurriculumVitae>>> GetAllByUserIdAsync(int id)
        {
            var result = await _curriculumVitaeDal.GetAllAsync(cv => cv.UserId == id);
            return new SuccessDataResult<List<CurriculumVitae>>(result, Messages.CurriculumVitae.GetAllByUserIdSuccess);
        }

        [ValidationAspect(typeof(CurriculumVitaeValidator))]
        public IResult Add(CurriculumVitae cv, IFormFile file)
        {
            var ruleResult = BusinessRules.Run(ExtensionCheck(file));
            if (ruleResult != null)
            {
                return ruleResult;
            }

            var pathCreator = PathCreator(file);
            cv.FilePath = pathCreator.fileName;
            cv.CreatedDate = DateTime.Now;
            cv.UpdatedDate = DateTime.Now;
            cv.Status = true;
            FileHelper.Add(file, pathCreator.path);
            _curriculumVitaeDal.Add(cv);
            return new SuccessResult(Messages.CurriculumVitae.AddSuccess);
        }

        [ValidationAspect(typeof(CurriculumVitaeValidator))]
        public async Task<IResult> AddAsync(CurriculumVitae cv, IFormFile file)
        {
            var ruleResult = BusinessRules.Run(ExtensionCheck(file));
            if (ruleResult != null)
            {
                return ruleResult;
            }

            var pathCreator = PathCreator(file);
            cv.FilePath = pathCreator.fileName;
            cv.CreatedDate = DateTime.Now;
            cv.UpdatedDate = DateTime.Now;
            cv.Status = true;
            await _curriculumVitaeDal.AddAsync(cv);
            await FileHelper.AddAsync(file, pathCreator.path);
            return new SuccessResult(Messages.CurriculumVitae.AddSuccess);
        }

        public IResult DeleteSoft(CurriculumVitae cv)
        {
            var result = _curriculumVitaeDal.Get(c => c.Id == cv.Id);
            var newCv = new CurriculumVitae()
            {
                Id = cv.Id,
                UserId = result.UserId,
                Name = result.Name,
                FilePath = result.FilePath,
                CreatedDate = result.CreatedDate,
                UpdatedDate = DateTime.Now,
                Status = false,
            };

            _curriculumVitaeDal.Update(newCv);
            return new SuccessResult(Messages.CurriculumVitae.DeleteSoftSuccess);
        }

        public IResult DeleteHard(CurriculumVitae cv)
        {
            var result = _curriculumVitaeDal.Get(c => c.Id == cv.Id);
            var filePath = $"{UploadPath}{result.FilePath}";
            var fileDelete = FileHelper.Delete(filePath);
            if (!fileDelete.Success)
            {
                return new ErrorResult(Messages.CurriculumVitae.DeleteHardError);
            }
            _curriculumVitaeDal.Delete(cv);
            return new SuccessResult(Messages.CurriculumVitae.DeleteHardSuccess);
        }

        public async Task<IResult> DeleteHardAsync(CurriculumVitae cv)
        {
            var result = await _curriculumVitaeDal.GetAsync(c => c.Id == cv.Id);
            var filePath = $"{UploadPath}{result.FilePath}";
            var fileDelete = await FileHelper.DeleteAsync(filePath);
            if (!fileDelete.Success)
            {
                return new ErrorResult(Messages.CurriculumVitae.DeleteHardError);
            }
            await _curriculumVitaeDal.DeleteAsync(cv);
            return new SuccessResult(Messages.CurriculumVitae.DeleteHardSuccess);
        }

        [ValidationAspect(typeof(CurriculumVitaeValidator))]
        public IResult Update(CurriculumVitae cv, IFormFile file)
        {
            var ruleResult = BusinessRules.Run(ExtensionCheck(file));
            if (ruleResult != null)
            {
                return ruleResult;
            }

            var oldData = _curriculumVitaeDal.Get(c => c.Id == cv.Id);
            FileHelper.Delete($"{UploadPath}{oldData.FilePath}");
            var pathCreator = PathCreator(file);
            cv.FilePath = pathCreator.fileName;
            cv.CreatedDate = oldData.CreatedDate;
            cv.UpdatedDate = DateTime.Now;

            FileHelper.Update($"{UploadPath}{oldData.FilePath}", file, pathCreator.path);
            _curriculumVitaeDal.Update(cv);
            return new SuccessResult(Messages.CurriculumVitae.UpdateSuccess);
        }

        [ValidationAspect(typeof(CurriculumVitaeValidator))]
        public async Task<IResult> UpdateAsync(CurriculumVitae cv, IFormFile file)
        {
            var ruleResult = BusinessRules.Run(ExtensionCheck(file));
            if (ruleResult != null)
            {
                return ruleResult;
            }

            var oldData = await _curriculumVitaeDal.GetAsync(c => c.Id == cv.Id);
            await FileHelper.DeleteAsync($"{UploadPath}{oldData.FilePath}");
            var pathCreator = PathCreator(file);
            cv.FilePath = pathCreator.fileName;
            cv.CreatedDate = oldData.CreatedDate;
            cv.UpdatedDate = DateTime.Now;

            await FileHelper.UpdateAsync($"{UploadPath}{oldData.FilePath}", file, pathCreator.path);
            await _curriculumVitaeDal.UpdateAsync(cv);
            return new SuccessResult(Messages.CurriculumVitae.UpdateSuccess);
        }


        #region FileOperations
        private static readonly string UploadPath = $@"{Environment.CurrentDirectory}\wwwroot\uploads\cv-files\";

        private (string path, string fileName) PathCreator(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            var uniqueFileName =
                $@"{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Year}-{Guid.NewGuid():N}{fileInfo.Extension}";
            var path = $@"{UploadPath}{uniqueFileName}";
            return (path, uniqueFileName);
        }

        private IResult ExtensionCheck(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName.ToLower());
            if (fileInfo.Extension != ".pdf")
            {
                return new ErrorResult(Messages.CurriculumVitae.CvFileExtensionError);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
