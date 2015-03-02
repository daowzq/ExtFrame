using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using CodeGenerator.Common;

namespace CodeGenerator.Common
{
    public class CodeGenFactory
    {
        public static DBTableInfo[] GetTables(BackgroundWorker bw)
        {
            DbProviderFactory instance = SqlClientFactory.Instance;
            IDbConnection dbConnection = null;
            dbConnection = instance.CreateConnection();
            IDbCommand dbCommand = null;
            IDataReader dataReader = null;
            List<DBTableInfo> list = new List<DBTableInfo>();
            if (bw != null)
            {
                bw.ReportProgress(0, "Connecting ...");
            }
            dbConnection.ConnectionString = ConfigOut.ConnectString;
            dbConnection.Open();
            try
            {
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES;";
                dataReader = dbCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    string @string = dataReader.GetString(0);
                    if (!@string.Equals("dtproperties"))
                    {
                        if (!@string.StartsWith("sys"))
                        {
                            DBTableInfo dbTableInfo = new DBTableInfo(@string);
                            dbTableInfo.GetFields();
                            list.Add(dbTableInfo);
                        }
                    }
                }
                dataReader.Close();
                if (bw != null)
                {
                    bw.ReportProgress(50, "Tables collected");
                }
                foreach (DBTableInfo current in list)
                {
                    current.CollectFields(dbConnection);
                }
                if (bw != null)
                {
                    bw.ReportProgress(100, "Fields collected");
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
                dbConnection.Close();
            }
            return list.ToArray();
        }
    }
}
