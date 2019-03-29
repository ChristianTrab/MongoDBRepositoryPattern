using MongoCore.Entities;
using MongoDAL.Mongo.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDAL.DataAccess
{
    public interface ICustomRepository : IRepository<CustomEntity>
    {
    }
}
