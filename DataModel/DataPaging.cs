using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class DataPaging
    {
        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount<T>()
        {
            return ActiveRecordMediator.Count(typeof(T));
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount<T>(params ICriterion[] ICrit)
        {
            return ActiveRecordMediator.Count(typeof(T), ICrit);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public static T[] FindAll<T>(int start, int pagesize)
        {
            Array array = null;
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize);
            return (T[])array;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="orders">new Order[] { new Order("CreateTime", false) }</param>
        /// <returns></returns>
        public static T[] FindAll<T>(int start, int pagesize, Order[] orders)
        {
            Array array = null;
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, orders);
            return (T[])array;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="Iquery">new DetachedQuery(SelectHql).SetParameter(....)</param>
        /// <returns></returns>
        public static T[] FindAll<T>(int start, int pagesize, IDetachedQuery Iquery)
        {
            Array array = null;
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, Iquery);
            return (T[])array;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="orders"></param>
        /// <param name="criteria">Expression.XX()</param>
        /// <returns></returns>
        public static T[] FindAll<T>(int start, int pagesize, Order[] orders, params ICriterion[] criteria)
        {
            Array array = null;
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, orders, criteria);
            return (T[])array;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="Hql">Hql语句</param>
        /// <returns></returns>
        public static T[] FindAll<T>(int start, int pagesize, string Hql)
        {
            Array array = null;
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, new NHibernate.Impl.DetachedQuery(Hql));
            return (T[])array;
        }
    }
}
