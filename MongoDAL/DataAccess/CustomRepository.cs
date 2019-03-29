using MongoCore.Entities;
using MongoDAL.Mongo.Base;
using MongoDAL.Mongo.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDAL.DataAccess
{
    public class CustomRepository : BaseRepository<CustomEntity>, ICustomRepository
    {
        public CustomRepository(IMongoContext context) : base(context)
        {

        }
    }
}
