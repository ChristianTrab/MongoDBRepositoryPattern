using MongoCore.Dto;
using MongoCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoServices
{
    public interface ICustomService
    {
        Task<CustomEntity> Create(CustomDto customDto);
        Task<IEnumerable<CustomEntity>> GetAll();
        Task<CustomEntity> Update(Guid id, CustomDto customDto);
        Task<CustomEntity> Get(Guid id);
        Task<CustomEntity> Delete(Guid id);
    }
}
