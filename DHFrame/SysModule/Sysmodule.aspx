<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sysmodule.aspx.cs" Inherits="HDFrame.SysModule.Sysmodule" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        var formatHours = function (v) {
            if (v < 1) {
                return Math.round(v * 60) + " mins";
            } else if (Math.floor(v) !== v) {
                var min = v - Math.floor(v);
                return Math.floor(v) + "h " + Math.round(min * 60) + "m";
            } else {
                return v + " hour" + (v === 1 ? "" : "s");
            }
        };

        var handler = function (grid, rowIndex, colIndex, actionItem, event, record, row) {
            Ext.Msg.alert('Editing' + (record.get('done') ? ' completed task' : ''), record.get('task'));
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server"></ext:ResourceManager>
        <ext:Viewport runat="server">
            <Items>
                <ext:Panel runat="server" Region="North" Heigh="90px">
                    <Items>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button runat="server" Text="添加子模块" Icon="ApplicationAdd"></ext:Button>
                                <ext:Button ID="Button1" runat="server" Icon="BookEdit" Text="修改"></ext:Button>
                                <ext:Button runat="server" Text="删除" Icon="Delete"></ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </Items>
                </ext:Panel>
                <%-- treePanel --%>
                <ext:TreePanel ID="SysModuleTree"
                    Region="Center"
                    runat="server"
                    UseArrows="true"
                    RootVisible="false"
                    MultiSelect="true"
                    SingleExpand="true"
                    FolderSort="true">
                    <Store>
                        <ext:TreeStore ID="TreeStore1" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server" IDProperty="ID">
                                    <Fields>
                                        <ext:ModelField Name="ID" Type="Auto" />
                                        <ext:ModelField Name="Code" Type="Auto" />
                                        <ext:ModelField Name="Name" Type="Auto" />
                                        <ext:ModelField Name="Type" Type="Auto" />
                                        <ext:ModelField Name="Url" Type="Auto" />
                                        <ext:ModelField Name="Description" Type="Auto" />
                                        <ext:ModelField Name="Status" Type="Auto" />
                                        <ext:ModelField Name="LastModifiedDate" Type="Date" />
                                        <ext:ModelField Name="CreateDate" Type="Date" />
                                        <ext:ModelField Name="SortIndex" Type="Auto" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                            <Proxy>
                                <ext:AjaxProxy Url="?action=reader">
                                    <Reader>
                                        <ext:JsonReader />
                                    </Reader>
                                </ext:AjaxProxy>
                            </Proxy>
                        </ext:TreeStore>
                    </Store>

                    <ColumnModel>
                        <Columns>
                            <ext:TreeColumn ID="TreeColumn1"
                                runat="server"
                                Text="应用/模块"
                                Width="240"
                                Sortable="true"
                                DataIndex="Name" />
                            <ext:Column runat="server" Text="编号"
                                Width="120"
                                DataIndex="Code">
                            </ext:Column>
                            <ext:Column ID="Column1"
                                runat="server"
                                Text="类型"
                                Flex="1"
                                Sortable="true"
                                DataIndex="user" />
                            <ext:Column runat="server"
                                Flex="1"
                                Text="URL">
                            </ext:Column>
                            <ext:Column ID="Column2" runat="server"
                                Flex="1"
                                Text="排序">
                            </ext:Column>
                            <ext:Column ID="Column3" runat="server"
                                Flex="1"
                                Text="状态">
                            </ext:Column>
                            <ext:Column ID="Column4" runat="server"
                                Flex="1"
                                Text="描述">
                            </ext:Column>
                        </Columns>
                    </ColumnModel>

                </ext:TreePanel>
            </Items>
        </ext:Viewport>

    </form>
</body>
</html>
