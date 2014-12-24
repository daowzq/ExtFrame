<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HDFrame.Default" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Default</title>

    <link href="ExtJs/resources/css/ext-all-neptune.css" rel="stylesheet" />
    <link href="Css/common.css" rel="stylesheet" />

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
    </style>
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
                var dirid = rcd.get('text'); //节点名称
                // var dirtype = rcd.raw.dirtype; //自定义数据

                var tab = Ext.getCmp("tabpanel");
                var childItem = tab.query();

                for (var i = 0; i < childItem.length; i++) {
                    if (childItem[i].xtype == "tab") {  //判断是tab控件

                    }
                }
                tab.add({
                    title: dirid,
                    closable: true
                });

            });

            //--------------功能列表--------------
            $('.left_nav').find("li").bind('click', function () {
                $(this).addClass("active").siblings("li").removeClass("active");
                var activeindex = $(this).index();
                if (activeindex == 1) {
                    $('.nav_dropdown').hide();
                    $('.nav_dr1').show();
                } else if (activeindex == 2) {
                    $('.nav_dropdown').hide();
                    $('.nav_dr2').show();
                } else {
                    $(".nav_dropdown").hide();
                    return false;
                }
                $(document).click(function () { $(".nav_dropdown").hide() });
                return false;
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
                    // collapsible: true,
                    // title: '功能列表',
                    //width: 180,
                    //items: [tree]
                    margins: '0 20 0 0',
                    width: 60
                }, {
                    id: 'tabpanel',
                    margin: '10 0 0 10',
                    region: 'center',
                    plain: true,
                    xtype: 'tabpanel',
                    activeTab: 0,
                    minTabWidth: 100,
                    items: [
                        {
                            title: '首页',
                            html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="../defaulttab.aspx" name="frameContent" frameborder="0"></iframe>'
                        },
                         {
                             title: '采购管理单',
                             closable: true,
                             html: '<iframe width="100%" height="100%" id="defaultPgFrame" src="../GridDemo.aspx" name="frameContent" frameborder="0"></iframe>'
                         }
                    ]

                }, {
                    margin: '3 0 0 0',
                    height: 40,
                    region: 'south',
                    hidden: true,
                    html: 'Information goes here'
                }]
            });
            $(".navigotar").appendTo("#westDiv-body").css({ "display": "" });

        });
    </script>
</head>
<body>
    <div class="navigotar" style="display: none">
        <ul class="left_nav">
            <li><a class="nav_home">首页</a></li>
            <li><a class="nav_procure">采购管理</a></li>
            <li><a class="nav_inventory">库存管理</a></li>
            <li><a class="nav_data">基础数据</a></li>
            <li><a class="nav_chemical">化学知识库</a></li>
            <li><a class="nav_warn">警告牌</a></li>
            <li><a class="nav_sys">系统管理</a></li>
        </ul>
        <div class="nav_dropdown nav_dr1">
            <i class="pic3"></i>
            <ul>
                <li><a>首页</a><i></i></li>
                <li><a>采购管理单</a><i></i></li>
                <li><a>供应商管理单</a><i></i></li>
            </ul>
        </div>
        <div class="nav_dropdown nav_dr2">
            <i class="pic3"></i>
            <ul>
                <li><a>库存查询</a><i></i></li>
                <li><a>新增入库</a><i></i></li>
            </ul>
        </div>
    </div>
</body>
</html>
