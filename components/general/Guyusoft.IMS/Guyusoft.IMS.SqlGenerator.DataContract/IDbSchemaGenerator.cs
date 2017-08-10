using System;
using System.Collections.Generic;

namespace Guyusoft.IMS.SqlGenerator.DataContract
{
    public interface IDbSchemaGenerator
    {
        IDictionary<string, object> GetFieldValuePair(object obj);

        IEnumerable<string> GetAllPublicFields(Type type);

        string GetTableName(Type type);

        string GetKeyName(Type type);

        T CreateInstance<T>();

        void SetPropertyValue<T>(T t, string propertyName, object val);
    }
}
