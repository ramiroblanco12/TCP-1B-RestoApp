<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Personalizar.aspx.cs" Inherits="AplicacionResto.Personalizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid bg-dark text-white">
        <ul class="nav nav-tabs">
            <li class="nav-item">

                <a class="nav-link active" data-bs-toggle="tab" aria-current="page" href="#configMozo">Configuración de mozos</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#configMesa">Configuración de mesas</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#registro">Crear usuario</a>
            </li>
        </ul>
    </div>
    <%--    -------------------------CREAR MOZO-------------------%>

    <div class="tab-content mt-3">
        <div class="tab-pane fade show active" id="configMozo" role="tabpanel">


            <div class="tab-content mt-3">
                <div class="tab-pane fade show active" id="Mozos" role="tabpanel" aria-labelledby="home-tab">

                    <asp:GridView ID="dgvMozos" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover" OnSelectedIndexChanged="CargarTXT">
                        <SelectedRowStyle ForeColor="Black" Font-Bold="true" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" HeaderText="Accion" SelectText="Seleccionar" />
                            <asp:BoundField HeaderText="Id" DataField="Id" />
                            <asp:BoundField HeaderText="Nombre Completo" DataField="NombreCompleto" />
                        </Columns>

                    </asp:GridView>


                    <div class="d-grid gap-2 d-md-flex justify-content-md-end">


                        <button type="button" class="btn btn-secondary me-md-2" data-bs-toggle="modal" data-bs-target="#formularioModalAgregarMozo">Agregar </button>

                        <button type="button" class="btn btn-secondary me-md-2" data-bs-toggle="modal" data-bs-target="#formularioModalModiMozo">Modificar </button>
                        <button type="button" class="btn btn-danger me-md-2" data-bs-toggle="modal" data-bs-target="#formularioModalEliminarMozo">Eliminar </button>
                        <button type="button" class="btn btn-success me-md-2" data-bs-toggle="modal" data-bs-target="#formularioAsignarMesa">Asignar mesa </button>

                    </div>
                </div>
            </div>
        </div>
    </div>


    <%--FORMULARIO Setear Mesa--%>
    <div class="modal fade" id="formularioAsignarMesa" tabindex="-1" aria-labelledby="formularioModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content bg-white text-dark">

                <div class="modal-header">
                    <h5 class="modal-title" id="formularioAsignar">Asignar Mesa</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="mb-3">
                                <label for="ddlAsignarMesa" class="form-label">Mesa</label>
                                <asp:DropDownList ID="ddlAsignarMesa" runat="server" OnSelectedIndexChanged="ddlAsignarMesa_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select">
                                    <asp:ListItem Text="Seleccione una mesa" Value="" Enabled="false" />
                                </asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <label for="ddlAsignarMozo" class="form-label">Mozo</label>
                                <asp:DropDownList ID="ddlAsignarMozo" runat="server" OnSelectedIndexChanged="ddlAsignarMozo_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select">
                                    <asp:ListItem Text="Seleccione un mozo" Value="" Enabled="false" />
                                </asp:DropDownList>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                <asp:Button ID="btnAsignar" runat="server" Text="Asignar" OnClick="btnAsignar_Click" CssClass="btn btn-primary" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>


    <%--FORMULARIO AGREGAR--%>
    <div class="modal fade" id="formularioModalAgregarMozo" tabindex="-1" aria-labelledby="formularioModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content bg-white text-dark">

                <div class="modal-header">
                    <h5 class="modal-title" id="formularioModalLabelAgregar">Agregar Mozo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnaceptar" runat="server" Text="aceptar" OnClick="btnaceptar_Click1" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%--FORMULARIO MODIFICAR--%>

    <div class="modal fade" id="formularioModalModiMozo" tabindex="-1" aria-labelledby="formularioModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content bg-white text-dark">

                <div class="modal-header">
                    <h5 class="modal-title" id="formularioModalLabelModi">Modificar Mozo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body">
                    <%if (sel)
                        {  %>
                    <div class="mb-3">
                        <label for="txtMiD" class="form-label">ID</label>
                        <asp:TextBox runat="server" ID="txtMId" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtmNombre" class="form-label">Nombre</label>
                        <asp:TextBox runat="server" ID="txtMNombre" CssClass="form-control" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnAceptarModificar" runat="server" Text="aceptar" OnClick="btnAceptarModificar_Click" CssClass="btn btn-primary" />
                    </div>
                    <%  }
                        else
                        { %>

                    <div class="alert alert-warning">Por favor, seleccione un producto antes de modificar.</div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>

                    </div>
                    <%}  %>
                </div>
            </div>
        </div>
    </div>

    <%--Formulario Eliminar--%>
    <div class="modal fade" id="formularioModalEliminarMozo" tabindex="-1" aria-labelledby="formularioModalLabelElim" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content bg-white text-dark">

                <div class="modal-header">
                    <h5 class="modal-title" id="formularioModalLabelEliminar">Eliminar Mozo</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body">
                    <% if (sel)
                        { %>
                    <div class="mb-3">
                        <label for="txtEiD" class="form-label">ID</label>
                        <asp:TextBox runat="server" ID="txtEId" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <div class="mb-3 text-center">
                            <label class="form-label">¿Está seguro que desea eliminar el objeto seleccionado?</label>
                        </div>
                        <div class="d-flex justify-content-around mt-3">
                            <asp:Button ID="btnAceptarEliminar" runat="server" Text="Aceptar" OnClick="btnAceptarEliminar_Click1" CssClass="btn btn-primary" />
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
    <%--    -------------------------FIN CREAR MOZO-------------------%>

    <%--    ------------------------- CREAR MESA-------------------%>
    <div class="tab-content mt-3">
        <div class="tab-pane fade" id="configMesa" role="tabpanel">

            <asp:TextBox ID="txtCantidadMesas" runat="server" placeholder="Ingrese cantidad de mesas"></asp:TextBox>
            <asp:Button ID="btnCrearMesas" runat="server" Text="Crear Mesas" OnClick="btnCrearMesas_Click" />
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>



        </div>

    </div>
    <%--    -------------------------FIN CREAR MESA-------------------%>



    <%--    -------------------Crear registro--------------%>
    <div class="tab-content mt-3">
        <div class="tab-pane fade" id="registro" role="tabpanel" aria-labelledby="home-tab">


            <div class="row justify-content-center">

                <div class="col-4">

                    <h2>Registro</h2>
                    <div class="mb-3">
                        <label class="form-label">Usuario</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuer" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Contraseña</label>
                        <div class="input-group">

                            <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" TextMode="Password" />


                            <button type="button" class="btn btn-outline-secondary" id="togglePassword">
                                <i class="bi bi-eye text-white"></i>
                            </button>
                        </div>
                    </div>


                    <script>
                        document.getElementById("togglePassword").addEventListener("click", function () {
                            const passwordInput = document.getElementById("<%= txtPass.ClientID %>");
                            const icon = this.querySelector("i");


                            if (passwordInput.type === "password") {
                                passwordInput.type = "text";
                                icon.classList.remove("bi-eye");
                                icon.classList.add("bi-eye-slash");
                            } else {
                                passwordInput.type = "password";
                                icon.classList.remove("bi-eye-slash");
                                icon.classList.add("bi-eye");
                            }
                        });
                    </script>
                    <div class="mb-3">
                        <label class="form-label">Tipo usuario</label>
                        <div class="col-5">
                            <div class="mb-3">

                                <asp:DropDownList ID="dropOpciones" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Seleccione un tipo de usuario" Value="0" />
                                    <asp:ListItem Text="Admin" Value="2" />
                                    <asp:ListItem Text="Empleado" Value="1" />
                                </asp:DropDownList>
                            </div>
                            <asp:Button Text="Registrar" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
                            <a href="Pedidos.aspx">cancelar</a>


                        </div>
                    </div>




                </div>

            </div>
        </div>

    </div>
    <%--    -------------------------FIN CREAR REGISTRO-------------------%>
</asp:Content>
