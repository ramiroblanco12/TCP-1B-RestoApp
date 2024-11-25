<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Personalizar.aspx.cs" Inherits="AplicacionResto.Personalizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="col-4">

            <h2>Registro</h2>
            <div class="mb-3">
                <label class="form-label">Usuario</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuer" />
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña"</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" />
            </div>
            <div class="mb-3">
                <label class="form-label">Tipo usuario</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtTipo"/>
            </div>
            <asp:Button  Text="Registrar"  CssClass="btn btn-primary" ID="btnRegistrarse" runat="server"/>
            <a href="#">cancelar</a>


        </div>
    </div>
</asp:Content>