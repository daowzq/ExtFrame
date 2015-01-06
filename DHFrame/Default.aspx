<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HDFrame.Default" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Default</title>

    <link href="ExtJs/resources/css/ext-all-neptune.css" rel="stylesheet" />
    <script type="text/javascript" src="ExtJs/ext-all-debug.js"></script>
    <script src="ExtJs/ext-theme-neptune.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <style type="text/css">
        .view-cls {
            background-color: rgb(231,234,236);
        }

        .navigotar {
            position: fixed;
            z-index: 999;
        }

        #westDiv {
            position: relative;
        }

        .bottomCls {
            background-color: #4B9CD7 !important;
        }

        #corpDiv {
            width: 300px;
            margin-top: 5px;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
    <script type="text/javascript">
        Ext.onReady(function () {
            var store = Ext.create('Ext.data.TreeStore', {
                root: {
                    expanded: true,
                    children: [
                        { text: "首页", id: 'tb0', leaf: true },
                        {
                            text: "系统权限", expanded: true, children: [
                               { text: "组织机构", leaf: true }, { text: "用户角色", leaf: true }
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
                var nodeName = rcd.get('text'); //节点名称
                var nodeid = rcd.get('id');
                //var dirtype = rcd.raw.dirtype; //自定义数据

                var tabCmp = Ext.ComponentQuery.query('tabpanel')[0];
                var childItem = tabCmp.items;
                //去除重复
                for (var i = 0; i < childItem.length; i++) {
                    if (childItem.items[0].id == nodeid) {
                        return;
                    }
                }
                //添加tab
                tabCmp.add({
                    id: nodeid,
                    title: nodeName,
                    closable: true
                });

            });

            //-------布局-------------------------
            Ext.create('Ext.container.Viewport', {
                layout: 'border',
                cls: 'view-cls',
                items: [{
                    region: 'north',
                    height: 66,
                    html: '<iframe width="100%" height="100%" id="topFrame" src="../toppage.aspx" name="frameContent" frameborder="0"></iframe>',
                    border: true,
                    margins: '0 0 0 0'
                }, {
                    id: 'westDiv',
                    region: 'west',
                    layout: 'fit',
                    margin: '10 0 0 0',
                    collapsible: true,
                    title: '功能列表',
                    width: 180,
                    items: [tree]
                }, {
                    id: 'tabpanel',
                    margin: '10 50 15 10',
                    region: 'center',
                    plain: true,
                    xtype: 'tabpanel',
                    activeTab: 2,
                    minTabWidth: 100,
                    items: [
                        {
                            title: '首页',
                            id: 'tb0',
                            html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="../defaulttab.aspx" name="frameContent" frameborder="0"></iframe>'
                        },
                         {
                             title: '采购管理单',
                             id: 'tab1',
                             closable: true,
                             html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="../GridDemo.aspx" name="frameContent" frameborder="0"></iframe>'
                         },
                           {
                               title: '商品信息',
                               id: 'tb12',
                               closable: true,
                               html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="../ProductDemo.aspx" name="frameContent" frameborder="0"></iframe>'
                           }
                    ]

                }, {
                    margin: '1 0 0 0',
                    height: 26,
                    region: 'south',
                    cls: 'bottomCls',
                    //hidden: true,
                    html: '<div class="bottomDiv"><div id="corpDiv">Copyright © 2014 目未视觉软件有限公司</div></div>'
                }]
            });
        });
    </script>
</head>
<body>
</body>
</html>
