using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDAL.Mongo.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
