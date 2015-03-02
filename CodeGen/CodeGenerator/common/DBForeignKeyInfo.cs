using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerator.Common
{
    public class DBForeignKeyInfo
    {
        private string _FK_Column;
        private string _PK_Table;
        private string _PK_Column;
        private string _Constraint_Name;
        private string _PK_DescriptorColumn;
        public string FK_Column
        {
            get
            {
                return this._FK_Column;
            }
        }
        public string PK_Table
        {
            get
            {
                return this._PK_Table;
            }
        }
        public string PK_Column
        {
            get
            {
                return this._PK_Column;
            }
        }
        public string Constraint_Name
        {
            get
            {
                return this._Constraint_Name;
            }
        }
        public string PK_DescriptorColumn
        {
            get
            {
                return this._PK_DescriptorColumn;
            }
            set
            {
                this._PK_DescriptorColumn = value;
            }
        }
        public DBForeignKeyInfo(string p_FK_Column, string p_PK_Table, string p_PK_Column, string p_Constraint_Name, string p_PK_DescriptorColumn)
        {
            this._FK_Column = p_FK_Column;
            this._PK_Table = p_PK_Table;
            this._PK_Column = p_PK_Column;
            this._Constraint_Name = p_Constraint_Name;
            this._PK_DescriptorColumn = p_PK_DescriptorColumn;
        }
    }
}
