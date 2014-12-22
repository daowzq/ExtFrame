<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultTab.aspx.cs" Inherits="HDFrame.DefaultTab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/common.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

    <style type="text/css">
        body {
            margin: 0px;
            padding: 10px 10px;
            background-color: #fff;
        }

        .main_home {
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="fl main_home">
            <div class="main_tab_cont">
                <!--main home-->
                <div class="home">
                    <div class="home_poster">
                        <img src="images/home_poster.png" height="331" width="1160" />
                    </div>
                    <div class="home_info">
                        <h3>欢迎您使用教学中心实验室资源管理系统!</h3>
                        <div class="home_warning">
                            <p><em>告警信息</em></p>
                            <p>您有<font>1</font>条新的采购单要审核   您有<font>1</font>条新的采购单要执行   <font>xxx</font>化学品库存过低  <a href="">请查看</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
