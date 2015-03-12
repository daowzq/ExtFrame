<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="HDFrame.Testpage.test" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script type="text/javascript">
        Ext.onReady(function () {
            function Person(name, job) {
                //this.name = name;
                //this.job = job;
            }
            function replaceObj(name, job) {
                this.name = name;
                this.job = job;
            }

            Person.prototype.name = "Nicholas";
            Person.prototype.age = 29;
            Person.prototype.job = "Software Engineer";
            Person.prototype.sayName = function () {
                alert(this.name);
            };
            var person1 = new Person("屌丝", "程序员");
            //var person2 = new Person();
            person1.sayName();

        })

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server"></ext:ResourceManager>
        <ext:Panel runat="server"
            Title="Title"
            Width="300px"
            Height="400px">
            <Content>
                <div>hello world!</div>
            </Content>
        </ext:Panel>
    </form>
</body>
</html>
