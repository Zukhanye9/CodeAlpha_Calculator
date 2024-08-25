<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="CalculatorWebApp.Calculator" %>

<!DOCTYPE html>
<link href="Content/styles.css" rel="stylesheet" />
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Calculator</title>
    <link rel="stylesheet" href="Content/styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="calculator">
            <asp:Label ID="lblDisplay" runat="server" CssClass="calculator-display" Text="0"></asp:Label>
            <div class="calculator-buttons">
                <asp:Button ID="btnClear" runat="server" Text="AC" CssClass="btn" OnClick="btnClear_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="DEL" CssClass="btn" OnClick="btnDelete_Click" />
                <asp:Button ID="btnDivide" runat="server" Text="/" CssClass="btn" OnClick="btnOperation_Click" />
                <asp:Button ID="btn7" runat="server" Text="7" CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btn8" runat="server" Text="8" CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btn9" runat="server" Text="9" CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btnMultiply" runat="server" Text="*" CssClass="btn" OnClick="btnOperation_Click" />
                <asp:Button ID="btn4" runat="server" Text="4" CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btn5" runat="server" Text="5" CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btn6" runat="server" Text="6" CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btnSubtract" runat="server" Text="-" CssClass="btn" OnClick="btnOperation_Click" />
                <asp:Button ID="btn1" runat="server" Text="1" CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btn2" runat="server" Text="2" CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btn3" runat="server" Text="3" CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="+" CssClass="btn" OnClick="btnOperation_Click" />
                <asp:Button ID="btn0" runat="server" Text="0" CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btnDecimal" runat="server" Text="." CssClass="btn" OnClick="btnDigit_Click" />
                <asp:Button ID="btnEquals" runat="server" Text="=" CssClass="btn" OnClick="btnEquals_Click" />
            </div>
        </div>
    </form>
</body>
</html>