<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinTesst.aspx.cs" Inherits="HDFrame.WinTesst" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="ExtJs/resources/css/ext-all.css" rel="stylesheet" />
    <script src="ExtJs/ext-all-debug-w-comments.js"></script>
    <script type="text/javascript">
        Ext.onReady(function () {
            Ext.create('Ext.panel.Panel', {
                id: "tPanel",
                title: 'Hello',
                width: 200,
                html: '<p>World!</p>',
                renderTo: Ext.getBody()
            });

            Ext.create(Ext.dd.DD, "tPanel");
        })
    </script>
</head>
<body>

    <div>
    </div>

</body>
</html>
