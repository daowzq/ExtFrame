using HDFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using DataModel;

namespace HDFrame.SysModule
{
    public partial class Sysmodule : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"] + "";
            switch (action)
            {
                case "reader":
                    LoadTreeData();
                    break;
            }
        }

        protected void LoadTreeData()
        {
            var list = DataModel.SysModule.FindAll();
            string TreeJson = Razor.DynamicJson.DynamicJsonConvert.SerializeObject(list);
            Response.Write(TreeJson);
            Response.End();
        }
    }
}