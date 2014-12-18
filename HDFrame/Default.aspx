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
                        { text: "detention", leaf: true },
                        {
                            text: "homework", expanded: true, children: [
                              { text: "book report", leaf: true },
                              { text: "alegrbra", leaf: true }
                            ]
                        },
                        { text: "buy lottery tickets", leaf: true }
                    ]
                }
            });

            var tree = Ext.create('Ext.tree.Panel', {
                store: store,
                rootVisible: false
            });


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
                    title: 'Navigation',
                    width: 150,
                    laytout: 'Vbox',
                    items: [tree]
                }, {
                    region: 'center',
                    xtype: 'tabpanel', // TabPanel itself has no title
                    activeTab: 0,      // First tab active by default
                    items: {
                        title: 'Default Tab',
                        html: 'The first tab\'s content. Others may be added dynamically'
                    }
                }, {
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
