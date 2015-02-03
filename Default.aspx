<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Show Tracker</h1>
    <div>
        <h3>Select an artist to see show details</h3>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="dropdown" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server" BorderColor="#006666" BorderStyle="Solid" BorderWidth="2px" CellPadding="3" CellSpacing="3" CssClass="grid"></asp:GridView>
    </div>
    </form>
</body>
</html>
