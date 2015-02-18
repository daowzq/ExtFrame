<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="HDFrame.Testpage.test" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server"></ext:ResourceManager>
        <ext:Panel runat="server"
             Title="Title"
             Width="300px" 
            Height="400px">
            <Content>
                <div>hello world!</div>
            </Content>
        </ext:Panel>
    </form>
</body>
</html>
