<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopPage.aspx.cs" Inherits="HDFrame.TopPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/common.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="fl logo">
                <h1 title="教学中心实验室资源管理系统"></h1>
            </div>
            <div class="fr person_mess">
                <div class="fl person_pic">
                    <img src="images/per.png" height="35" width="35" />
                </div>
                <div class="fl person_name">
                    <div class="dorp_btn">
                        <span class="name">刘三</span>
                        <i class="pic1"></i>
                    </div>
                </div>
                <div class="person_dropdown">
                    <i class="pic2"></i>
                    <ul>
                        <li><a href="">退出</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
