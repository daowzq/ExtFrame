using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerator.Common
{
    interface IDbInfo
    {
        /// <summary>
        /// 测试是否可以访问数据库
        /// </summary>
        /// <returns></returns>
        bool IsCanAccess();
    }
}
