using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CodeGenerator.Common
{
    public class DBTableInfo
    {
        private static string[] _Singular2Plural = new string[]
		{
			"Search",
			"Searches",
			"Switch",
			"Switches",
			"Fix",
			"Fixes",
			"Box",
			"Boxes",
			"Process",
			"Processes",
			"Address",
			"Addresses",
			"Case",
			"Cases",
			"Stack",
			"Stacks",
			"Wish",
			"Wishes",
			"Fish",
			"Fish",
			"Category",
			"Categories",
			"Query",
			"Queries",
			"Ability",
			"Abilities",
			"Agency",
			"Agencies",
			"Movie",
			"Movies",
			"Archive",
			"Archives",
			"Index",
			"Indices",
			"Wife",
			"Wives",
			"Safe",
			"Saves",
			"Half",
			"Halves",
			"Move",
			"Moves",
			"Salesperson",
			"Salespeople",
			"Person",
			"People",
			"Spokesman",
			"Spokesmen",
			"Man",
			"Men",
			"Woman",
			"Women",
			"Basis",
			"Bases",
			"Diagnosis",
			"Diagnoses",
			"Datum",
			"Data",
			"Medium",
			"Media",
			"Analysis",
			"Analyses",
			"Node_child",
			"Node_children",
			"Child",
			"Children",
			"Experience",
			"Experiences",
			"Day",
			"Days",
			"Comment",
			"Comments",
			"Newsletter",
			"Newsletters",
			"Old_News",
			"Old_News",
			"News",
			"News",
			"Series",
			"Series",
			"Species",
			"Species",
			"Quiz",
			"Quizzes",
			"Perspective",
			"Perspectives",
			"Ox",
			"Oxen",
			"Photo",
			"Photos",
			"Buffalo",
			"Buffaloes",
			"Tomato",
			"Tomatoes",
			"Dwarf",
			"Dwarves",
			"Elf",
			"Elves",
			"Information",
			"Information",
			"Equipment",
			"Equipment",
			"Bus",
			"Buses",
			"Status",
			"Statuses",
			"Status_code",
			"Status_codes",
			"Mouse",
			"Mice",
			"Louse",
			"Lice",
			"House",
			"Houses",
			"Octopus",
			"Octopi",
			"Virus",
			"Viri",
			"Alias",
			"Aliases",
			"Portfolio",
			"Portfolios",
			"Vertex",
			"Vertices",
			"Matrix",
			"Matrices",
			"Axis",
			"Axes",
			"Testis",
			"Testes",
			"Crisis",
			"Crises",
			"Rice",
			"Rice",
			"Shoe",
			"Shoes",
			"Horse",
			"Horses",
			"Prize",
			"Prizes",
			"Edge",
			"Edges"
		};
        private string _TableName;
        private DBFieldInfo[] _DbFieldInfo;
        private DBRelatedTableInfo[] _DbRelatedTableInfo;
        public static string LastWord(string mixedCaseName)
        {
            string result = mixedCaseName;
            char[] array = mixedCaseName.ToCharArray();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                bool flag = char.IsUpper(array[i]);
                if (flag)
                {
                    result = mixedCaseName.Substring(i);
                    break;
                }
            }
            return result;
        }
        public static string GetSingularName(string tableName)
        {
            string result = tableName;
            int length = tableName.Length;
            bool flag = false;
            for (int i = 0; i < DBTableInfo._Singular2Plural.Length; i += 2)
            {
                if (tableName.EndsWith(DBTableInfo._Singular2Plural[i + 1], StringComparison.CurrentCultureIgnoreCase))
                {
                    string str = DBTableInfo._Singular2Plural[i];
                    string text = DBTableInfo._Singular2Plural[i + 1];
                    result = tableName.Substring(0, length - text.Length) + str;
                    flag = true;
                }
            }
            if (!flag)
            {
                if (tableName.EndsWith("sses"))
                {
                    result = tableName.Substring(0, length - 2);
                }
                else
                {
                    if (tableName.EndsWith("ches"))
                    {
                        result = tableName.Substring(0, length - 2);
                    }
                    else
                    {
                        if (!tableName.EndsWith("us"))
                        {
                            if (tableName.EndsWith("s"))
                            {
                                result = tableName.Substring(0, length - 1);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public DBTableInfo(string p_TableName)
        {
            this._TableName = p_TableName;
        }
        public DBFieldInfo[] GetFields()
        {
            return this._DbFieldInfo;
        }
        public DBRelatedTableInfo[] GetDbRelatedTableInfo()
        {
            return this._DbRelatedTableInfo;
        }
        public bool HasProperty(string prop)
        {
            DBFieldInfo[] dbFieldInfo = this._DbFieldInfo;
            bool result;
            for (int i = 0; i < dbFieldInfo.Length; i++)
            {
                DBFieldInfo dbFieldInfo2 = dbFieldInfo[i];
                if (dbFieldInfo2.Column_Name == prop)
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }
        internal void CollectFields(IDbConnection p_Conn)
        {
            string commandText = "SELECT c.Column_Name, c.Column_Default, c.Is_Nullable,  c.Data_Type, c.Character_Maximum_Length,  c.Numeric_Precision, c.Numeric_Scale  FROM Information_Schema.Columns c  WHERE Table_Name = @Table  ORDER BY Ordinal_Position ; ";
            List<DBFieldInfo> list = new List<DBFieldInfo>();
            IDbCommand dbCommand = null;
            IDataReader dataReader = null;
            try
            {
                dbCommand = p_Conn.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = commandText;
                IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
                dbDataParameter.ParameterName = "Table";
                dbDataParameter.Value = this._TableName;
                dbCommand.Parameters.Add(dbDataParameter);
                dataReader = dbCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    int num = 0;
                    string p_Column_Name = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    string p_Column_Default = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    string text = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    string p_Data_Type = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    int p_Character_Maximum_Length = dataReader.IsDBNull(num) ? 0 : dataReader.GetInt32(num);
                    num++;
                    int p_Numeric_Precision = (int)(dataReader.IsDBNull(num) ? 0 : dataReader.GetByte(num));
                    num++;
                    int p_Numeric_Scale = dataReader.IsDBNull(num) ? 0 : dataReader.GetInt32(num);
                    num++;
                    bool p_Is_Nullable = text.Equals("YES");
                    DBFieldInfo item = new DBFieldInfo(p_Column_Name, p_Column_Default, p_Is_Nullable, p_Character_Maximum_Length, p_Numeric_Precision, p_Numeric_Scale, p_Data_Type);
                    list.Add(item);
                }
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                }
            }
            this._DbFieldInfo = list.ToArray();
            this.CollectPrimaryKeys(p_Conn);
            this.CollectForeignKeys(p_Conn);
            this.CollectDependentTables(p_Conn);
        }
        private void CollectPrimaryKeys(IDbConnection p_Conn)
        {
            string commandText = "SELECT tc.CONSTRAINT_NAME, tc.TABLE_NAME, ccu.COLUMN_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu ON\tccu.CONSTRAINT_CATALOG = tc.CONSTRAINT_CATALOG\tAND ccu.TABLE_NAME = tc.TABLE_NAME\tAND ccu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME WHERE tc.CONSTRAINT_TYPE = 'PRIMARY KEY' AND tc.TABLE_NAME = @Table";
            IDbCommand dbCommand = null;
            IDataReader dataReader = null;
            try
            {
                dbCommand = p_Conn.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = commandText;
                IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
                dbDataParameter.ParameterName = "Table";
                dbDataParameter.Value = this._TableName;
                dbCommand.Parameters.Add(dbDataParameter);
                dataReader = dbCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    int num = 0;
                    string arg_7A_0 = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    string arg_97_0 = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    string value = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    DBFieldInfo[] dbFieldInfo = this._DbFieldInfo;
                    for (int i = 0; i < dbFieldInfo.Length; i++)
                    {
                        DBFieldInfo dbFieldInfo2 = dbFieldInfo[i];
                        if (dbFieldInfo2.Column_Name.Equals(value))
                        {
                            dbFieldInfo2.Is_Primary_Key = true;
                        }
                    }
                }
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                }
                dataReader = null;
                dbCommand = null;
            }
        }
        private void CollectForeignKeys(IDbConnection p_Conn)
        {
            string commandText = "SELECT FK.TABLE_NAME AS K_Table, CU.COLUMN_NAME AS FK_Column, PK.TABLE_NAME AS PK_Table, PT.COLUMN_NAME AS PK_Column, C.CONSTRAINT_NAME AS Constraint_Name FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK   ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU\tON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME INNER JOIN (\t\tSELECT i1.TABLE_NAME, i2.COLUMN_NAME\t\tFROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1\t\tINNER JOIN\tINFORMATION_SCHEMA.KEY_COLUMN_USAGE i2\t\t\tON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME\t\tWHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'\t\t) PT ON PT.TABLE_NAME = PK.TABLE_NAME WHERE FK.TABLE_NAME = @Table";
            List<DBForeignKeyInfo> list = new List<DBForeignKeyInfo>();
            IDbCommand dbCommand = null;
            IDataReader dataReader = null;
            try
            {
                dbCommand = p_Conn.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = commandText;
                IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
                dbDataParameter.ParameterName = "Table";
                dbDataParameter.Value = this._TableName;
                dbCommand.Parameters.Add(dbDataParameter);
                dataReader = dbCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    int num = 0;
                    string arg_8D_0 = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    string p_FK_Column = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    string p_PK_Table = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    string p_PK_Column = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    string p_Constraint_Name = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    DBForeignKeyInfo item = new DBForeignKeyInfo(p_FK_Column, p_PK_Table, p_PK_Column, p_Constraint_Name, "Name");
                    list.Add(item);
                }
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                }
                dataReader = null;
                dbCommand = null;
            }
            commandText = "SELECT TOP 1 COLUMN_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE DATA_TYPE IN ('nvarchar', 'varchar') AND CHARACTER_MAXIMUM_LENGTH > 3 AND TABLE_NAME = @Table ORDER BY CASE WHEN COLUMN_NAME LIKE '%NAME%' THEN 0 ELSE 1 END, ORDINAL_POSITION";
            foreach (DBForeignKeyInfo current in list)
            {
                try
                {
                    dbCommand = p_Conn.CreateCommand();
                    dbCommand.CommandType = CommandType.Text;
                    dbCommand.CommandText = commandText;
                    IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
                    dbDataParameter.ParameterName = "Table";
                    dbDataParameter.Value = current.PK_Table;
                    dbCommand.Parameters.Add(dbDataParameter);
                    dataReader = dbCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        int num = 0;
                        string pK_DescriptorColumn = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                        num++;
                        current.PK_DescriptorColumn = pK_DescriptorColumn;
                    }
                }
                finally
                {
                    if (dataReader != null)
                    {
                        dataReader.Close();
                    }
                    if (dbCommand != null)
                    {
                        dbCommand.Dispose();
                    }
                    dataReader = null;
                    dbCommand = null;
                }
                DBFieldInfo[] dbFieldInfo = this._DbFieldInfo;
                for (int i = 0; i < dbFieldInfo.Length; i++)
                {
                    DBFieldInfo dbFieldInfo2 = dbFieldInfo[i];
                    if (dbFieldInfo2.Column_Name.Equals(current.FK_Column))
                    {
                        dbFieldInfo2.ForeignKeyInfo = current;
                        break;
                    }
                }
            }
        }
        private void CollectDependentTables(IDbConnection p_Conn)
        {
            string commandText = "\r\nSELECT k.table_name, k.column_name --, k.ordinal_position\r\nFROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE k\r\nLEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS c\r\n            ON k.table_name = c.table_name AND k.table_schema = c.table_schema\r\n            AND k.table_catalog = c.table_catalog AND k.constraint_catalog = c.constraint_catalog\r\n            AND k.constraint_name = c.constraint_name\r\nLEFT JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc\r\n            ON rc.constraint_schema = c.constraint_schema AND rc.constraint_catalog = c.constraint_catalog\r\n            AND rc.constraint_name = c.constraint_name\r\nLEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu\r\n            ON rc.unique_constraint_schema = ccu.constraint_schema\r\n            AND rc.unique_constraint_catalog = ccu.constraint_catalog\r\n            AND rc.unique_constraint_name = ccu.constraint_name\r\nWHERE k.constraint_catalog = DB_NAME()\r\nAND c.constraint_type = 'FOREIGN KEY'\r\nAND ccu.table_name = @Table\r\nORDER BY k.constraint_name, k.ordinal_position";
            List<DBRelatedTableInfo> list = new List<DBRelatedTableInfo>();
            IDbCommand dbCommand = null;
            IDataReader dataReader = null;
            try
            {
                dbCommand = p_Conn.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = commandText;
                IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
                dbDataParameter.ParameterName = "Table";
                dbDataParameter.Value = this._TableName;
                dbCommand.Parameters.Add(dbDataParameter);
                dataReader = dbCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    int num = 0;
                    string p_Table_Name = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    string p_Column_Name = dataReader.IsDBNull(num) ? "" : dataReader.GetString(num);
                    num++;
                    DBRelatedTableInfo item = new DBRelatedTableInfo(p_Table_Name, p_Column_Name);
                    list.Add(item);
                }
                this._DbRelatedTableInfo = list.ToArray();
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                if (dbCommand != null)
                {
                    dbCommand.Dispose();
                }
                dataReader = null;
                dbCommand = null;
            }
        }
        public string GetClassName()
        {
            return DBTableInfo.GetSingularName(this._TableName);
        }
        public string GetLabel()
        {
            return DBFieldInfo.MakeLabel(this._TableName);
        }
        public DBFieldInfo GetPkField()
        {
            DBFieldInfo result = null;
            DBFieldInfo[] dbFieldInfo = this._DbFieldInfo;
            for (int i = 0; i < dbFieldInfo.Length; i++)
            {
                DBFieldInfo dbFieldInfo2 = dbFieldInfo[i];
                if (dbFieldInfo2.Is_Primary_Key)
                {
                    result = dbFieldInfo2;
                    break;
                }
            }
            return result;
        }
        public override string ToString()
        {
            return this._TableName;
        }
    }
}
