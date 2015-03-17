<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sysmodule.aspx.cs" Inherits="HDFrame.SysModule.Sysmodule" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
    
   </style>
    <script type="text/javascript">
        function addSubModel(treepanel) {
            var recd = App.SysModuleTree.getSelectionModel().getLastSelected();
            App.addSubModelWin.show();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server"></ext:ResourceManager>
        <ext:Viewport runat="server">
            <Items>
                <ext:Window runat="server"
                    Title="添加子模块"
                    Width="480"
                    Hidden="true"
                    Height="400"
                    Resizable="false"
                    Draggable="false"
                    ID="addSubModelWin">
                    <Items>
                        <ext:FormPanel runat="server">
                            <Items>
                                <ext:Label
                                    MarginSpec="10 10 20 10"
                                    Text="当前节点："
                                    runat="server">
                                </ext:Label>
                                <ext:TextField ID="TextField6"
                                    runat="server"
                                    Name="ID"
                                    Hidden="true">
                                </ext:TextField>
                                <ext:TextField
                                    runat="server"
                                    Hidden="true"
                                    Name="ParentID">
                                </ext:TextField>
                                <ext:TextField ID="TextField7"
                                    runat="server"
                                    Hidden="true"
                                    Name="IsLeaf">
                                </ext:TextField>
                                <ext:TextField runat="server" Name="Path" Hidden="true"></ext:TextField>
                                <ext:FieldSet ID="FieldSet1"
                                    Title="基本属性"
                                    MarginSpec="0 5"
                                    Layout="FormLayout"
                                    runat="server">
                                    <Items>
                                        <ext:Panel
                                            ID="pnlTableLayout"
                                            runat="server"
                                            Region="Center"
                                            Border="false"
                                            Layout="TableLayout">
                                            <LayoutConfig>
                                                <ext:TableLayoutConfig Columns="2" />
                                            </LayoutConfig>
                                            <Items>

                                                <ext:TextField ID="TextField1"
                                                    runat="server"
                                                    LabelWidth="80"
                                                    Name="Name"
                                                    Width="210"
                                                    LabelAlign="Right"
                                                    FieldLabel="模块名">
                                                </ext:TextField>
                                                <ext:TextField ID="TextField2"
                                                    LabelWidth="80"
                                                    Name="Code"
                                                    Width="210"
                                                    LabelAlign="Right"
                                                    runat="server"
                                                    FieldLabel="编号">
                                                </ext:TextField>
                                                <ext:ComboBox runat="server"
                                                    LabelWidth="80"
                                                    LabelAlign="Right"
                                                    Editable="false"
                                                    Name="Type"
                                                    FieldLabel="模块类型"
                                                    Width="210">
                                                    <Items>
                                                        <ext:ListItem Text="应用" Value="0"></ext:ListItem>
                                                        <ext:ListItem Text="页面" Value="1"></ext:ListItem>
                                                        <ext:ListItem Text="入口" Value="2"></ext:ListItem>
                                                    </Items>
                                                </ext:ComboBox>
                                                <ext:TextField
                                                    ID="TextField4"
                                                    LabelWidth="80"
                                                    Width="210"
                                                    Name="SortIndex"
                                                    LabelAlign="Right"
                                                    MaskRe="/\d+/"
                                                    runat="server"
                                                    FieldLabel="排序号">
                                                </ext:TextField>
                                                <ext:TextField
                                                    ID="TextField3"
                                                    runat="server"
                                                    Name="Url"
                                                    LabelAlign="Right"
                                                    Width="420"
                                                    LabelWidth="80"
                                                    Flex="1" ColSpan="2"
                                                    FieldLabel="URL">
                                                </ext:TextField>
                                                <ext:TextField
                                                    ID="TextField5"
                                                    runat="server"
                                                    LabelAlign="Right"
                                                    Name="Icon"
                                                    Width="420"
                                                    LabelWidth="80"
                                                    Flex="1"
                                                    ColSpan="2"
                                                    FieldLabel="图标">
                                                </ext:TextField>
                                                <ext:TextField runat="server"
                                                    LabelAlign="Right"
                                                    Width="420"
                                                    LabelWidth="80"
                                                    Flex="1"
                                                    Name="Description"
                                                    ColSpan="2"
                                                    FieldLabel="描述">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:FieldSet>
                                <ext:FieldSet ID="FieldSet2"
                                    Title="配置属性"
                                    MarginSpec="0 5"
                                    Layout="FormLayout"
                                    Height="120"
                                    runat="server">
                                    <Items>
                                        <ext:Panel
                                            ID="Panel1"
                                            runat="server"
                                            Region="Center"
                                            Border="false"
                                            Height="50"
                                            Layout="AbsoluteLayout">
                                            <Items>
                                                <ext:Checkbox
                                                    runat="server"
                                                    X="0"
                                                    Y="10"
                                                    Name="IsQuickSearch"
                                                    LabelAlign="Right"
                                                    FieldLabel="快速搜索">
                                                </ext:Checkbox>
                                                <ext:Checkbox
                                                    runat="server"
                                                    X="120"
                                                    Y="10"
                                                    Name="IsRecyclable"
                                                    LabelAlign="Right"
                                                    FieldLabel="可回收">
                                                </ext:Checkbox>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                    <DockedItems>
                        <ext:Toolbar Height="30px" Dock="Bottom" Border="true" runat="server" Layout="AbsoluteLayout">
                            <Items>
                                <ext:Button ID="Button2" Icon="Disk" runat="server" Text="保存" Width="60px" Height="27" X="250" Y="0">
                                    <Listeners>
                                        <Click Handler=""></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button3" Icon="PageDelete" Text="清空" runat="server" Width="60px" Height="27" X="320" Y="0">
                                    <Listeners>
                                        <Click Fn=""></Click>
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="Button4" Icon="Cancel" Text="取消" runat="server" Width="60px" Height="27" X="390" Y="0">
                                    <Listeners>
                                        <Click Handler="App.addSubModelWin.close();"></Click>
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </DockedItems>
                </ext:Window>

                <ext:Panel runat="server" Region="North" Heigh="90px">
                    <Items>
                        <ext:Toolbar runat="server">
                            <Items>
                                <ext:Button runat="server" Text="添加子模块" Icon="ApplicationAdd">
                                    <Listeners>
                                        <Click Handler="addSubModel()"></Click>
                                    </Listeners>
                                </ext:Button>
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
                                        <ext:ModelField Name="ParentID" Type="Auto" />
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
                            <Root>
                                <ext:Node NodeID="root" Text="模块管理" Leaf="false" Expanded="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="ID" Value="root" Mode="Value" />
                                        <ext:ConfigItem Name="Name" Value="模块管理" />
                                    </CustomAttributes>
                                </ext:Node>
                            </Root>
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
                                Locked="true"
                                DataIndex="Code">
                            </ext:Column>
                            <ext:Column ID="Column1"
                                runat="server"
                                Text="类型"
                                Width="100"
                                Sortable="true"
                                DataIndex="Type" />
                            <ext:Column ID="Column3" runat="server"
                                DataIndex="Status"
                                Width="100"
                                Text="状态">
                            </ext:Column>
                            <ext:Column ID="Column2" runat="server"
                                DataIndex="SortIndex"
                                Width="80"
                                Text="排序">
                            </ext:Column>
                            <ext:Column runat="server"
                                Flex="1"
                                DataIndex="Url"
                                Text="URL">
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
