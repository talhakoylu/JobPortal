﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public IResult Add(CurriculumVitae cv)
        {
            _curriculumVitaeDal.Add(cv);
            return new SuccessResult(Messages.CurriculumVitae.AddSuccess);
        }

        public async Task<IResult> AddAsync(CurriculumVitae cv)
        {
            await _curriculumVitaeDal.AddAsync(cv);
            return new SuccessResult(Messages.CurriculumVitae.AddSuccess);
        }

        public IResult Delete(CurriculumVitae cv)
        {
            _curriculumVitaeDal.Delete(cv);
            return new SuccessResult(Messages.CurriculumVitae.DeleteSuccess);
        }

        public async Task<IResult> DeleteAsync(CurriculumVitae cv)
        {
            await _curriculumVitaeDal.DeleteAsync(cv);
            return new SuccessResult(Messages.CurriculumVitae.DeleteSuccess);
        }

        public IResult Update(CurriculumVitae cv)
        {
            _curriculumVitaeDal.Update(cv);
            return new SuccessResult(Messages.CurriculumVitae.UpdateSuccess);
        }

        public async Task<IResult> UpdateAsync(CurriculumVitae cv)
        {
            await _curriculumVitaeDal.UpdateAsync(cv);
            return new SuccessResult(Messages.CurriculumVitae.UpdateSuccess);
        }
    }
}