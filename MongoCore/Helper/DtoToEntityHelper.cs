using MongoCore.Dto;
using MongoCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoCore.Helper
{
    public static class DtoToEntityHelper
    {

        public static CustomEntity ToEntity(this CustomDto entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CustomEntity
            {
                Username = entity.Username ?? new string(""),
                Password = entity.Password ?? new string(""),
                TestInt = entity.TestInt
            };
        }
    }
}
