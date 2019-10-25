<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<%@ Register Assembly="ServerControl1" Namespace="ServerControl1" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>   
</head>
<body>
    <form id="form1" runat="server">

        <cc1:TabBar ID="TabBar1" runat="server" WD="10">
            <TabWithDelButtons>
                <cc1:TabButtonWithDelimiter ID="TabButtonWithDelimiter1" runat="server" ButtonText ="Text1" IsActive="true" />
                <cc1:TabButtonWithDelimiter ID="TabButtonWithDelimiter2" runat="server" ButtonText="Text2" />
            </TabWithDelButtons>
        </cc1:TabBar>
    </form>
</body>
</html>
