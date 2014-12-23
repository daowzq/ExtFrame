﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using HDFrame.Common;
using Newtonsoft.Json.Linq;

namespace HDFrame
{
    public partial class GridDemo : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] + "" == "ajax")
            {
                Response.Write(ResponseJsonBySQL());
                Response.End();
            }

            if (Request["action"] + "" == "data")
            {
                string data = Request["data"] + "";
                var jObj = (JObject)JsonConvert.DeserializeObject(data);
                string sql = @"insert into Employee 
                             select NEWID(), '{0}',{1},'{2}','{3}','{4}',GETDATE(),NEWID(),'WGM'";
                sql = string.Format(sql, (jObj["Name"] + "").Replace("\"", ""),
                                          (jObj["Age"] + "").Replace("\"", ""),
                                           (jObj["Job"] + "").Replace("\"", ""),
                                            (jObj["Email"] + "").Replace("\"", ""),
                                             (jObj["Postion"] + "").Replace("\"", ""));

                DBHelper.DbHelperSQL.ExecuteSql(sql);
                Response.Write("1");
                Response.End();
            }
        }

        /// <summary>
        /// 输出Json字符串
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private string ResponseJsonBySQL()
        {
            //if (string.IsNullOrEmpty(sql)) return null;

            string sql = "select * from Employee where 1=1 ";

            //查询数据时
            if (!string.IsNullOrEmpty(GridPagingStruct.search))
            {
                var jarr = (JArray)JsonConvert.DeserializeObject(GridPagingStruct.search);
                string Name = (jarr[0]["Name"] + "").Replace("\"\"", "");
                string Age = (jarr[1]["Age"] + "").Replace("\"\"", "");
                string Email = (jarr[2]["Email"] + "").Replace("\"\"", "");

                if (!string.IsNullOrEmpty(Name))
                {
                    sql += " and Name like '%" + Name + "%' ";
                }
                if (!string.IsNullOrEmpty(Age))
                {
                    sql += " and Age=" + Age.Replace("\"", "");
                }
                if (!string.IsNullOrEmpty(Email))
                {
                    sql += " and Email like '%" + Email + "%' ";
                }
            }
            sql = sql + " order by CreateTime desc";
            DataSet ds = DBHelper.DbHelperSQL.Query(sql);
            DataTable dt = ds.Tables[0];
            DataTable newDt = GetPagedTable(dt, GridPagingStruct.Page, GridPagingStruct.PageSize);
            GridJsonStruct gjs = new GridJsonStruct(newDt, dt.Rows.Count);

            return JsonConvert.SerializeObject(gjs, new JsonConverter[] { new DataTableConverter(), new IsoDateTimeConverter() });
        }


        /// <summary>
        /// DataTable分页
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="PageIndex">页索引,注意：从1开始</param>
        /// <param name="PageSize">每页大小</param>
        /// <returns>分好页的DataTable数据</returns>
        public static DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0) { return dt; }
            DataTable newdt = dt.Copy();
            newdt.Clear();
            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
            { return newdt; }

            if (rowend > dt.Rows.Count)
            { rowend = dt.Rows.Count; }
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }
            return newdt;
        }

    }

}