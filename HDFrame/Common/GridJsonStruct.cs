using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace HDFrame.Common
{
    /// <summary>
    /// Grid需要的Json数据结构
    /// </summary>
    public class GridJsonStruct
    {
        public readonly int total;
        public readonly object items;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="_total">数据条数</param>
        public GridJsonStruct(DataTable dt, int _total)
        {
            if (dt != null)
                this.items = dt;
            total = _total;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">数据集对象</param>
        /// <param name="_total">数据条数</param>
        public GridJsonStruct(object obj, int _total)
        {
            if (obj != null)
                this.items = obj;
            total = _total;
        }

        /// <summary>
        /// 获取条数
        /// </summary>
        public int Total
        {
            get
            {
                return total;
            }
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        public object Items
        {
            get
            {
                return items;
            }
        }
        /// <summary>
        /// 用于扩展
        /// </summary>
        public string extend { get; set; }
    }
}