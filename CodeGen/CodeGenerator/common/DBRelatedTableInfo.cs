using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerator.Common
{
    public class DBRelatedTableInfo
    {
        private string _Column_Name;
        private string _Table_Name;
        public string Column_Name
        {
            get
            {
                return this._Column_Name;
            }
        }
        public string Table_Name
        {
            get
            {
                return this._Table_Name;
            }
        }
        public DBRelatedTableInfo(string p_Table_Name, string p_Column_Name)
        {
            this._Table_Name = p_Table_Name;
            this._Column_Name = p_Column_Name;
        }
        public string GetClassName()
        {
            return DBTableInfo.GetSingularName(this._Table_Name);
        }
    }
}
