using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDFrame.Common
{
    public class BasePage : Page
    {
        #region ASP.NET 事件

        /// <summary>
        /// 初始化方法（先于Page_Load和OnLoad执行）
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.EnableViewState = false;   // 禁用ViewState
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            /*--写事件日志开始--*/

            throw ex;
        }

        /// <summary>
        /// 渲染前触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Page_PreRender(object sender, EventArgs e)
        {
        }

        //去缓存
        protected override void OnLoad(EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Expires = 0;
            base.OnLoad(e);
        }

        #endregion 事件
    }
}