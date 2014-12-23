<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Grid.Master" AutoEventWireup="true" CodeBehind="GridDemo.aspx.cs" Inherits="HDFrame.GridDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        Ext.onReady(function () {
            //顶部工具栏
            var menuBtn = Ext.create('Ext.panel.Panel', {
                region: 'north',
                height: 40,
                border: true,
                //margin: '0 5 3 10',
                dockedItems: [{
                    xtype: 'toolbar',
                    dock: 'top',
                    items: [{
                        xtype: 'button', text: '新增', minWidth: 85, handler: function () {
                            var win = Ext.create('Ext.window.Window', {
                                id: 'dataAddWin',
                                title: '添加',
                                height: 230,
                                width: 300,
                                layout: 'form',
                                items: [
                                    { id: 't_Name', xtype: 'textfield', name: 'Name', fieldLabel: '姓名', labelWidth: 50, labelAlign: "left" },
                                    { id: 't_Age', xtype: 'textfield', name: 'Age', fieldLabel: '年龄', labelWidth: 50, labelAlign: "left" },
                                    { id: 't_Job', xtype: 'textfield', name: 'Job', fieldLabel: '工作', labelWidth: 50, labelAlign: "left" },
                                    { id: 't_Email', xtype: 'textfield', name: 'Email', fieldLabel: '邮件', labelWidth: 50, labelAlign: "left" },
                                    { id: 't_Postion', xtype: 'textfield', name: 'Postion', fieldLabel: '职位', labelWidth: 50, labelAlign: "left" }
                                ],
                                dockedItems: [{
                                    xtype: 'toolbar',
                                    dock: 'bottom',
                                    items: [
                                        {
                                            xtype: 'button', text: '保存', handler: function () {
                                                var obj = {
                                                    Name: win.getComponent("t_Name").getValue(),
                                                    Age: win.getComponent("t_Age").getValue(),
                                                    Job: win.getComponent("t_Job").getValue(),
                                                    Email: win.getComponent("t_Email").getValue(),
                                                    Postion: win.getComponent("t_Postion").getValue()
                                                };
                                                Ext.Ajax.request({
                                                    url: '?action=data',
                                                    params: {
                                                        data: Ext.encode(obj)
                                                    },
                                                    success: function (response) {
                                                        var store = Ext.data.StoreManager.lookup('simpsonsStore');
                                                        store.load();
                                                        // process server response here
                                                    }
                                                });

                                            }
                                        }
                                    ]
                                }]
                            }).show();

                        }
                    },
        { xtype: 'button', text: '删除', minWidth: 85 },
        { xtype: 'button', text: '编辑', minWidth: 85 },
        { xtype: 'button', text: '导出', minWidth: 85 }
                    ]
                }],
            });

            var store = Ext.create('Ext.data.Store', {
                storeId: 'simpsonsStore',
                pageSize: 20,
                autoLoad: { start: 0, limit: 20 },
                fields: ['Name', 'Age', 'Job', 'Email', 'Postion', 'CreateTime'],
                proxy: {
                    type: 'ajax',
                    url: '?action=ajax',
                    reader: {
                        type: 'json',
                        root: 'items',
                        totalProperty: 'total'
                    }
                }
            });

            //*查询处理函数,scope
            function schHandler(eType) {
                var schBar = Ext.getCmp("schBar");  //当前工具栏ID
                var store = grid.getStore();        //grid的Store
                var queryArr = [];                  //查询对象

                var items = schBar.query();
                for (var i = 0; i < items.length; i++) {
                    //当前控件的类型
                    var currXType = items[i].getXType() + "";
                    var xtype = "textfield|numberfield|textareafield|combodatefield";
                    if (currXType == "button" && items[i] == this) continue;

                    if (xtype.indexOf(currXType) > -1) {
                        //这里处理查询的值
                        var queryObj = {};
                        queryObj[items[i].name] = items[i].getValue();
                        queryArr.push(queryObj);
                    }
                }
                //输出调试信息
                console.log(Ext.encode(queryArr))
                //查询条件
                store.getProxy().extraParams.search = Ext.encode(queryArr);
                store.load();
            }

            var grid = Ext.create('Ext.grid.Panel', {
                region: "center",
                //height: 500,
                //title: '详细数据',
                //selModel: Ext.create('Ext.selection.CheckboxModel', { mode: "SIMPLE" }),
                //selModel: Ext.create('Ext.selection.RowModel', { mode: "SIMPLE" }),
                store: Ext.data.StoreManager.lookup('simpsonsStore'),
                columns: [
                     { xtype: 'rownumberer', sortable: false, width: 50 },
                    { id: 'Name', text: '姓名', dataIndex: 'Name' },
                    { id: 'Age', text: '年龄', dataIndex: 'Age', width: 100 },
                    { id: 'Job', text: '工作', dataIndex: 'Job', width: 200 },
                    { id: 'Email', text: '邮件', dataIndex: 'Email', width: 200 },
                    { id: 'Postion', text: '职位', dataIndex: 'Postion', width: 100 },
                    { id: 'CreateTime', text: '创建时间', dataIndex: 'CreateTime', width: 180 },
                    { text: '链接', dataIndex: 'Name', width: 200, flex: 1, renderer: rowRender }
                ],
                dockedItems: [{
                    id: 'schBar',
                    xtype: 'toolbar',
                    dock: 'top',
                    height: 40,
                    layout: {
                        type: 'table',
                        columns: 4
                    },
                    items: [
                    {
                        xtype: 'textfield', name: 'Name', fieldLabel: '姓名', labelWidth: 50, labelAlign: "left",
                        listeners: {
                            specialkey: function (field, e) {
                                if (e.getKey() == Ext.EventObject.ENTER) {
                                    schHandler.call(this, "");
                                }
                            }
                        }
                    },
                    {
                        xtype: 'textfield', name: 'Age', fieldLabel: '年龄', labelWidth: 50, labelAlign: "left",
                        listeners: {
                            specialkey: function (field, e) {
                                if (e.getKey() == Ext.EventObject.ENTER) {
                                    schHandler.call(this, "");
                                }
                            }
                        }
                    },
                    {
                        xtype: 'textfield', name: 'Email', fieldLabel: '邮件', labelWidth: 50, labelAlign: "left",
                        listeners: {
                            specialkey: function (field, e) {
                                if (e.getKey() == Ext.EventObject.ENTER) {
                                    schHandler.call(this, "");
                                }
                            }
                        }
                    },
                    { xtype: 'button', text: '查询', handler: schHandler }
                    ]
                }],
                bbar: Ext.create('Ext.PagingToolbar', {
                    store: Ext.data.StoreManager.lookup('simpsonsStore'),
                    displayMsg: '显示{0} - {1}，共{2}条',
                    beforePageText: "第",
                    afterPageText: "页，共{0}页",
                    emptyMsg: "无数据",
                    displayInfo: true
                })
            });

            // 页面视图
            viewport = new Ext.container.Viewport({
                layout: "border",
                items: [menuBtn, grid]
            });
        })

        function rowRender(value, cellmeta, record, rowIndex, columnIndex, store) {
            return "<a href='javascript:;'>" + value + "</a>";
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
