<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="AplicacionResto.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid bg-dark text-white">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" data-bs-toggle="tab" aria-current="page" href="#mesas">Mesas</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#mostrador">Mostrador</a>
            </li>


        </ul>

        <div class="container mt-3 bg-dark">
            <div class="row justify-content-center">
                <div class="col-md-8 col-lg-6">
                    <div class="tab-content mt-3">
                        <div class="tab-pane fade show active" style="align-content: center; justify-content: center; height:auto; padding-bottom: 0;" id="mesas" role="tabpanel" aria-labelledby="home-tab">

                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="mb-3">
                                        <label for="ddlProducto" class="form-label">Producto</label>
                                        <asp:DropDownList ID="ddlProducto" runat="server" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select">
                                            <asp:ListItem Text="Seleccione un producto" Value="" Enabled="false" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="mb-3">
                                        <label for="txtPrecio" class="form-label">Precio</label>
                                        <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" Enabled="false" />
                                    </div>
                                    <div class="mb-3">
                                        <label for="txtCantidad" class="form-label">Cantidad</label>
                                        <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>



                            <asp:UpdatePanel ID="upProductos" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgvProductos" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" DataKeyNames="IdProducto">
                                        <Columns>
                                            <asp:BoundField DataField="NombreProducto" HeaderText="Producto" />
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                            <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEliminarProducto" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminarProducto_Click" CommandArgument='<%# Eval("IdProducto") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                    <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto"
                                        CssClass="btn btn-primary mb-3" OnClick="btnAgregarProducto_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <div class="d-flex justify-content-center">
                                <asp:Button ID="btnAgregarPedido" runat="server" Text="FINALIZAR PEDIDO" OnClick="btnAgregarPedido_Click" CssClass="btn btn-success mb-3" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="tab-pane fade bg-dark" style="height: 100vh; " id="mostrador" role="tabpanel">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

            <div class="tab-content mt-3 bg-dark" style="height: 100%;">
                <div class="tab-pane fade show active" id="Pedidos" role="tabpanel" aria-labelledby="pedidos-tab">
                    
                    <asp:GridView ID="dgvPedidos" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" />
                            <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="Id Mozo" DataField="IdMozo" />
                            <asp:BoundField HeaderText="Id Mesa" DataField="IdMesa" />
                            <asp:BoundField HeaderText="Monto Total" DataField="Monto" DataFormatString="{0:C}" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" CssClass="btn btn-primary btn-sm" OnClick="btnVerDetalle_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="mt-3">
                    
                    <asp:GridView ID="dgvDetallePedido" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover">
                        <Columns>
                            <asp:BoundField HeaderText="Producto" DataField="NombreProducto" />
                            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                            <asp:BoundField HeaderText="Precio" DataField="Precio" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

    </div>









</asp:Content>

