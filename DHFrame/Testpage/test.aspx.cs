using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
namespace HDFrame.Testpage
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                
            }
        }
        /// <summary>
        /// MongoDb 测试
        /// </summary>
        protected void MongoDbT()
        {
            string Config = Razor.Mongo.Connnection.ServerAddress;
            string DBName = Razor.Mongo.Connnection.DbName;

            Razor.Mongo.MongoBaseAction BA = new Razor.Mongo.MongoBaseAction(DBName);
            Stuend st = new Stuend();
            st.Name = "张三";
            st.Age = 18;
            BA.Insert<Stuend>(typeof(Stuend).Name, st);
            X.Msg.Alert("Tip", "插入成功").Show();
        }
        class Stuend
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}