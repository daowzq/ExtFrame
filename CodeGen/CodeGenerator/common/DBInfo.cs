using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
namespace CodeGenerator.Common
{
    public abstract class DBInfo
    {
        /// <summary>
        /// 获取可访问的数据库名
        /// </summary>
        /// <returns></returns>
        public abstract string[] CanAccessDbName();

        /// <summary>
        /// 获取Table
        /// </summary>
        /// <param name="DbName"></param>
        /// <returns></returns>
        public abstract string[] GetAllTableName(string DbName);

        /// <summary>
        /// 获取列信息
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public abstract DataTable GetColumnsInfo(string TableName);

        /// <summary>
        /// 获取当前数据库名
        /// </summary>
        /// <returns></returns>
        public abstract String GetDBName();

        /// <summary>
        /// 当前程序执行目录
        /// </summary>
        public static string CurreExcPath
        {
            get
            {
                return System.Windows.Forms.Application.StartupPath + "\\Templates\\";
            }
        }
        /// <summary>
        /// 模板文件
        /// </summary>
        public static List<string> TemplateFiles
        {
            get
            {
                List<string> list = new List<string>();

                if (Directory.Exists(CurreExcPath))
                {
                    var FileNames = Directory.GetFiles(CurreExcPath);
                    foreach (var item in FileNames)
                    {
                        list.Add(item);
                    }
                }
                else
                {
                    throw new Exception("找不到'Templates'目录！");
                }
                return list;
            }
        }
    }
}
