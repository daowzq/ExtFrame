using Castle.ActiveRecord;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Razor.Data;

namespace DataModel
{
    [Serializable]
    public abstract class ModelBase<T> : EntityBase<T> where T : ModelBase<T>, new()
    {
        public IList<T> GetOtherMap(string tableName, string withwhereString)
        {
            string query = string.Format("select * from {0} {1}", tableName, withwhereString);
            return (IList<T>)ActiveRecordMediator<T>.Execute(
                delegate(ISession session, object instance)
                {
                    //return session.CreateSQLQuery(query, "synonym", typeof(SmartDeal)).List<SmartDeal>();   
                    return session.CreateSQLQuery(query).AddEntity("synonym", typeof(T)).List<T>();
                }, new T());
        }
    }
}
