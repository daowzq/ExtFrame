<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HDFrame.Default" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>智能学习管理系统</title>
    <link href="ExtJs/resources/css/ext-all-neptune.css" rel="stylesheet" />
    <script type="text/javascript" src="ExtJs/ext-all-debug.js"></script>
    <script src="ExtJs/ext-theme-neptune.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>

    <style type="text/css">
        .view-port {
            background-color: #e7eaec;
        }
        /*top样式*/
        #topdiv-innerCt {
            display: block !important;
        }

        #topdiv .logo {
            width: 260px;
            height: 98%;
            border: solid 1px rgb(30,150,200);
            background-repeat: no-repeat;
            background-image: url("Images/logo.png");
            background-position-x: 10px;
            background-position-y: 6px;
        }

            #topdiv .logo > h1 {
                margin-top: 20px;
                margin-left: 70px;
                color: #fff;
                font-size: 1.3em;
                font-family: 'Microsoft YaHei', 微软雅黑;
            }
        /*底部版权样式*/
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

        function topArrowClick(obj) {
            if ($(obj).find("img").attr("src").indexOf("bar4") > -1) {
                $(obj).css({ "top": 1 });
                var imgPath = $(obj).find("img").attr("src");
                $(obj).find("img").attr("src", imgPath.replace("bar4", "bar3"));
                Ext.getCmp("topdiv").setHeight(10);
                $(".logo").hide();
            } else {
                var imgPath = $(obj).find("img").attr("src");
                $(obj).find("img").attr("src", imgPath.replace("bar3", "bar4"));
                $(obj).css({ "top": 58 });
                Ext.getCmp("topdiv").setHeight(66);
                $(".logo").show();
            }
        }

        Ext.onReady(function () {
            //---------treePanel-------------------
            var store = Ext.create('Ext.data.TreeStore', {
                root: {
                    expanded: true,
                    children: [
                        { text: "首页", id: 'tb0', leaf: true },
                        {
                            text: "系统权限",
                            id: 'tb1',
                            expanded: true,
                            children: [
                               { id: 'tb1_1', text: "组织机构", leaf: true }, { id: 'tb1_2', text: "用户角色", leaf: true }
                            ]
                        },
                        { id: 'tb2', text: "个人配置", leaf: true }
                    ]
                }
            });

            var tree = Ext.create('Ext.tree.Panel', {
                title: "系统权限",
                store: store,
                border: false,
                rootVisible: false
            });

            tree.on("itemclick", function (view, rcd, item, idx, event, eOpts) {
                var nodeName = rcd.get('text'); //节点名称
                var nodeid = rcd.get('id');
                //var dirtype = rcd.raw.dirtype; //自定义数据
                var tabItem = Ext.getCmp(nodeid);
                var tabCmp = Ext.ComponentQuery.query('tabpanel')[0];
                if (tabItem == null) {
                    //添加tab
                    tabCmp.add({
                        id: nodeid,
                        title: nodeName,
                        closable: true
                    });
                } else {
                    //重复点击
                    tabCmp.setActiveTab(tabItem)
                }
            });

            //-------布局-------------------------
            Ext.create('Ext.container.Viewport', {
                layout: 'border',
                cls: "view-port",
                items: [{
                    id: "topdiv",
                    region: 'north',
                    height: 66,
                    layout: 'auto',
                    html: "<div style='height:66px; background-color: #1e96c8;'>"
                         + "<div class='logo'>"
                            + "<h1>目未智能学习管理中心</h1>"
                         + "</div>"
                         + "<div id='top-div' onclick='topArrowClick(this)' style='width:50px; z-index:999; position:absolute;top:58px;left:49%; cursor:pointer;'>"
                            + "<img src='Images/bar4.png' />"
                         + "</div>"
                         + "</div>",
                    border: false
                }, {
                    id: 'westDiv',
                    region: 'west',
                    layout: {
                        // layout-specific configs go here
                        type: 'accordion',
                        animate: true
                    },
                    margin: '10 0 10 0',
                    collapsible: true,
                    title: '功能列表',
                    width: 180,
                    items: [tree, {
                        title: 'Panel 2',
                        html: 'Panel content!'
                    }],
                    dockedItems: [{
                        xtype: 'toolbar',
                        dock: 'bottom',
                        cls: 'aaaa',
                        bodyStyle: "padding-left:0px !important",
                        items: [{
                            width: 170,
                            xtype: "textfield",
                            emptyText: "Search here..."
                        }]
                    }]
                }, {
                    id: 'tabpanel',
                    margin: '10 15 10 10',
                    region: 'center',
                    plain: true,
                    xtype: 'tabpanel',
                    activeTab: 3,
                    minTabWidth: 100,
                    items: [
                        {
                            title: '首页',
                            id: 'tb0',
                            html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="../defaulttab.aspx" name="frameContent" frameborder="0"></iframe>'
                        }, {
                            title: '商品信息',
                            id: 'tb12',
                            closable: true,
                            html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="../ProductDemo.aspx" name="frameContent" frameborder="0"></iframe>'
                        },
                           {
                               title: '测试页面',
                               id: 'tb13',
                               closable: true,
                               html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="../testpage/test.aspx" name="frameContent" frameborder="0"></iframe>'
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
