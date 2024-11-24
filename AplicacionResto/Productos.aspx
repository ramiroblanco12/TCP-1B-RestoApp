<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="AplicacionResto.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid bg-dark text-white">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" data-bs-toggle="tab" aria-current="page" href="#Productos">Lista Productos</a>
            </li>
        </ul>
    </div>

    <div class="tab-content mt-3">
        <div class="tab-pane fade show active" id="Productos" role="tabpanel" aria-labelledby="home-tab">

            <asp:GridView ID="dgvProductos" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover" OnSelectedIndexChanged="CargarTXT">
                <SelectedRowStyle ForeColor="Black" Font-Bold="true" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" HeaderText="Accion" SelectText="Seleccionar" />
                    <asp:BoundField HeaderText="Id" DataField="Id" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                </Columns>

            </asp:GridView>

            <div class="d-grid gap-2 d-md-flex justify-content-md-end">


                <button type="button" class="btn btn-secondary me-md-2" data-bs-toggle="modal" data-bs-target="#formularioModalAgregar">Agregar </button>

                <button type="button" class="btn btn-secondary me-md-2" data-bs-toggle="modal" data-bs-target="#formularioModalModi">Modificar </button>
                <button type="button" class="btn btn-danger me-md-2" data-bs-toggle="modal" data-bs-target="#formularioModalEliminar">Eliminar </button>

            </div>
        </div>
    </div>

    <%--FORMULARIO AGREGAR--%>
    <div class="modal fade" id="formularioModalAgregar" tabindex="-1" aria-labelledby="formularioModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content bg-white text-dark">

                <div class="modal-header">
                    <h5 class="modal-title" id="formularioModalLabelAgregar">Agregar Producto</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body">
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtDesc" class="form-label">Descripción</label>
                        <asp:TextBox runat="server" ID="txtDesc" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtPrecio" class="form-label">Precio</label>
                        <asp:TextBox runat="server" type="number" ID="txtPrecio" CssClass="form-control" />
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <asp:Button ID="btnaceptar" runat="server" Text="aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

    <%--FORMULARIO MODIFICAR--%>

    <div class="modal fade" id="formularioModalModi" tabindex="-1" aria-labelledby="formularioModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content bg-white text-dark">

                <div class="modal-header">
                    <h5 class="modal-title" id="formularioModalLabelModi">Modificar Producto</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body">
                    <% if (seleccionado)
                        { %>
                    <div class="mb-3">
                        <label for="txtMiD" class="form-label">ID</label>
                        <asp:TextBox runat="server" ID="txtMId" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtmNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtMNombre" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtMDesc" class="form-label">Descripción</label>
                        <asp:TextBox runat="server" ID="txtMDesc" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtMPrecio" class="form-label">Precio</label>
                        <asp:TextBox runat="server" ID="txtMPrecio" CssClass="form-control" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnAceptarModificar" runat="server" Text="aceptar" OnClick="btnModificar_Click" CssClass="btn btn-primary" />
                    </div>
                    <% }
                        else
                        { %>

                    <div class="alert alert-warning">Por favor, seleccione un producto antes de modificar.</div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>

                    </div>
                    <% } %>
                </div>
            </div>
        </div>
    </div>

    <%--Formulario Eliminar--%>
    <div class="modal fade" id="formularioModalEliminar" tabindex="-1" aria-labelledby="formularioModalLabelElim" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content bg-white text-dark">

                <div class="modal-header">
                    <h5 class="modal-title" id="formularioModalLabelEliminar">Eliminar Producto</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body">
                    <% if (seleccionado)
                        { %>
                    <div class="mb-3">
                        <label for="txtEiD" class="form-label">ID</label>
                        <asp:TextBox runat="server" ID="txtEID" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <div class="mb-3 text-center">
                            <label class="form-label">¿Está seguro que desea eliminar el objeto seleccionado?</label>
                        </div>
                        <div class="d-flex justify-content-around mt-3">
                            <asp:Button ID="btnAceptarEliminar" runat="server" Text="Aceptar" OnClick="btnAceptarEliminar_Click" CssClass="btn btn-primary" />
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        </div>
                    </div>

                    <% }
                        else
                        { %>
                    <div class="alert alert-warning">Por favor, seleccione un producto antes de eliminar.</div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>

                    </div>
                    <% } %>
                </div>


            </div>
        </div>
    </div>

  </asp:Content>