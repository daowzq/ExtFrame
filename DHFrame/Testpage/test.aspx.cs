﻿using System;
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
                MongoDbT();
            }
        }

        protected void MongoDbT()
        {
            string Config = Razor.Mongo.Connnection.ServerAddress;
            X.Msg.Alert("Tip", Config).Show();
        }
    }
}