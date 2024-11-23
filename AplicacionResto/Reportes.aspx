<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="AplicacionResto.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="progress" role="progressbar" aria-label="Success example" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
  <div class="progress-bar bg-success" style="width: 25%"></div>
</div>
<div class="progress" role="progressbar" aria-label="Info example" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">
  <div class="progress-bar bg-info" style="width: 50%"></div>
</div>
<div class="progress" role="progressbar" aria-label="Warning example" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100">
  <div class="progress-bar bg-warning" style="width: 75%"></div>
</div>
<div class="progress" role="progressbar" aria-label="Danger example" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100">
  <div class="progress-bar bg-danger" style="width: 100%"></div>
</div>

</asp:Content>