using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CodeGenerator.Common
{
    public class MSSQLDbInfo : DBInfo, IDbInfo
    {
        /// <summary>
        /// 获取当前连接数据库名
        /// </summary>
        /// <returns></returns>
        public override string GetDBName()
        {
            string sql = " select DB_NAME()";
            return DBHelper.DbHelperSQL.GetSingle(sql) + "";
        }

        /// <summary>
        /// 获取可访问数据库名
        /// </summary>
        /// <returns></returns>
        public override string[] CanAccessDbName()
        {
            DataSet ds = DBHelper.DbHelperSQL.Query(" exec sp_helpdb");
            DataTable dt = ds.Tables[0];
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ("master,model,msdb,msdb,tempdb".Split(',').Contains(dt.Rows[i][0] + ""))
                    continue;
                list.Add(dt.Rows[i][0] + "");
            }
            return list.ToArray();
        }

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <param name="DbName"></param>
        /// <returns></returns>
        public override string[] GetAllTableName(string DbName)
        {
            string sql = "select * from sysobjects where xtype in ('U','V')";
            DataSet ds = DBHelper.DbHelperSQL.Query(sql);
            DataTable dt = ds.Tables[0];
            List<string> list = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(dt.Rows[i][0] + "");
            }
            return list.ToArray();
        }

        /// <summary>
        /// 获取列信息,[ColumnName,DataType,IsNull,Length]
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetColumnsInfo(string TableName)
        {
            if (string.IsNullOrEmpty(TableName))
            {
                throw new Exception("参数为空！");
            }
            string sql = @"select c.COLUMN_NAME ColumnName,DATA_TYPE DataType,IS_NULLABLE [IsNull],CHARACTER_MAXIMUM_LENGTH [Length]
                           from information_schema.columns  c  where table_name = N'" + TableName + "'";
            DataTable dt = DBHelper.DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 判断连接是否可用
        /// </summary>
        /// <returns></returns>
        public bool IsCanAccess()
        {
            string sql = "select 'aa' ";
            object obj = DBHelper.DbHelperSQL.GetSingle(sql);
            if (obj + "" == "aa")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
