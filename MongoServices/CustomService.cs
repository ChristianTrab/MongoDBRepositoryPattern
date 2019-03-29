using MongoCore.Dto;
using MongoCore.Entities;
using MongoCore.Helper;
using MongoDAL.DataAccess;
using MongoDAL.Mongo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoServices
{
    public class CustomService : ICustomService
    {
        private readonly ICustomRepository _customRepository;
        private readonly IUnitOfWork _uow;

        public CustomService(ICustomRepository customRepository, IUnitOfWork uow)
        {
            _customRepository = customRepository;
            _uow = uow;
        }

        public async Task<CustomEntity> Create(CustomDto customDto)
        {
            try
            {
                var entity = customDto.ToEntity();

                _customRepository.Add(entity);

                // it will be null
                var testEntity = await _customRepository.GetById(entity.Id);

                // If everything is ok then:
                await _uow.Commit();

                // The product will be added only after commit
                testEntity = await _customRepository.GetById(entity.Id);

                return testEntity;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<CustomEntity> Delete(Guid id)
        {
            try
            {
                _customRepository.Remove(id);

                // it won't be null
                var entity = await _customRepository.GetById(id);

                // If everything is ok then:
                await _uow.Commit();

                // not it must by null
                entity = await _customRepository.GetById(id);

                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public async Task<CustomEntity> Get(Guid id)
        {
            try
            {
                var entity = await _customRepository.GetById(id);
                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<IEnumerable<CustomEntity>> GetAll()
        {
            try
            {
                var entity = await _customRepository.GetAll();
                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<CustomEntity> Update(Guid id, CustomDto customDto)
        {
            if (customDto != null)
            {
                try
                {
                    var entity = await _customRepository.GetById(id);
                    entity.Username = customDto.Username;
                    entity.Password = customDto.Password;
                    entity.TestInt = customDto.TestInt;

                    //Update
                    _customRepository.Update(entity);

                    await _uow.Commit();

                    return entity;
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
            else
            {
                return null;
            }


        }
    }
}
