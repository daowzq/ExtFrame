<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Grid.Master" AutoEventWireup="true" CodeBehind="GridDemo.aspx.cs" Inherits="HDFrame.GridDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        Ext.onReady(function () {
            Ext.create('Ext.data.Store', {
                storeId: 'simpsonsStore',
                fields: ['name', 'email', 'phone'],
                data: {
                    'items': [
                        { 'name': 'Lisa', "email": "lisa@simpsons.com", "phone": "555-111-1224" },
                        { 'name': 'Bart', "email": "bart@simpsons.com", "phone": "555-222-1234" },
                        { 'name': 'Homer', "email": "home@simpsons.com", "phone": "555-222-1244" },
                        { 'name': 'Marge', "email": "marge@simpsons.com", "phone": "555-222-1254" }
                    ]
                },
                proxy: {
                    type: 'memory',
                    reader: {
                        type: 'json',
                        root: 'items'
                    }
                }
            });

            Ext.create('Ext.grid.Panel', {
                title: '详细数据',
                store: Ext.data.StoreManager.lookup('simpsonsStore'),
                columns: [
                    { text: '姓名', dataIndex: 'name' },
                    { text: 'Email', dataIndex: 'email', width: 200 },
                    { text: 'Phone', dataIndex: 'phone', width: 200 }
                ],
                height: 200,
                bbar: Ext.create('Ext.PagingToolbar', {
                    pageSize: 10,
                    store: Ext.data.StoreManager.lookup('simpsonsStore'),
                    displayInfo: true
                }),
                renderTo: Ext.getBody()
            });
        })

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
