using HDFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using DataModel;
using Razor.DynamicJson;

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
            List<NodeObject> NodeList = GetTree(list.ToArray(), "root");
            string TreeJson = Razor.DynamicJson.DynamicJsonConvert.SerializeObject(NodeList);
            Response.Write(TreeJson);
            Response.End();
        }

        private List<NodeObject> GetTree(DataModel.SysModule[] Ent, string ParentID)
        {
            List<NodeObject> list = new List<NodeObject>();
            DataModel.SysModule[] TempEnt = Ent.Where(ten => ten.ParentID == ParentID).ToArray();

            //递归调用
            foreach (var item in TempEnt)
            {
                NodeObject tree = new NodeObject();
                tree.ParentID = item.ParentID;
                tree.SortIndex = item.SortIndex;
                tree.Status = item.Status;
                tree.Url = item.Url;
                tree.Name = item.Name;
                tree.LastModifiedDate = item.LastModifiedDate;
                tree.Code = item.Code;
                tree.CreateDate = item.CreateDate;
                tree.Description = item.Description;
                tree.Type = item.Type;

                var TempRecd = Ent.Where(ten => ten.ParentID == item.ID).ToArray();
                if (TempRecd.Count() > 0)
                {
                    tree.leaf = false;
                    tree.children = GetTree(Ent, item.ID);
                    list.Add(tree);
                }
                else
                {
                    tree.leaf = true;
                    tree.children = null;
                    list.Add(tree);
                }
            }
            return list;
        }
    }


    public class NodeObject
    {
        public string iconCls { get; set; }
        public bool leaf { get; set; }
        public List<NodeObject> children { get; set; }

        //扩展属性
        public string ParentID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public int? SortIndex { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}