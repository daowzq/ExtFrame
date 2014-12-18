<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HDFrame.Default" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Default</title>
    <link href="ExtJs/resources/css/ext-all.css" rel="stylesheet" />
    <script type="text/javascript" src="ExtJs/ext-all-debug.js"></script>
    <script type="text/javascript">
        Ext.onReady(function () {
            var store = Ext.create('Ext.data.TreeStore', {
                root: {
                    expanded: true,
                    children: [
                        { text: "首页", leaf: true },
                        {
                            text: "系统权限", expanded: true, children: [
                              { text: "组织机构", leaf: true },
                              { text: "用户角色", leaf: true }
                            ]
                        },
                        { text: "个人配置", leaf: true }
                    ]
                }
            });

            var tree = Ext.create('Ext.tree.Panel', {
                store: store,
                border: false,
                rootVisible: false
            });

            tree.on("itemclick", function (view, rcd, item, idx, event, eOpts) {
                var dirid = rcd.get('text'); //节点id
                //  var dirtype = rcd.raw.dirtype; //自定义数据
                alert(dirid);
            });

            //-------布局-------------------------
            Ext.create('Ext.container.Viewport', {
                layout: 'border',
                items: [{
                    region: 'north',
                    height: 50,
                    html: '<h1 class="x-panel-header">Page Title</h1>',
                    border: false,
                    margins: '0 0 5 0'
                }, {
                    region: 'west',
                    collapsible: true,
                    title: '功能列表        ',
                    width: 180,
                    layout: 'fit',
                    items: [tree]
                }, {
                    margin: '0 0 0 10',
                    region: 'center',
                    plain: true,
                    xtype: 'tabpanel',
                    activeTab: 0,
                    items: [{
                        title: 'Default Tab',
                        html: 'The first tab\'s content. Others may be added dynamically'
                    }]
                }, {
                    margin: '3 0 0 0',
                    height: 40,
                    region: 'south',
                    html: 'Information goes here'
                }]
            });
        });
    </script>
</head>
<body>
</body>
</html>
