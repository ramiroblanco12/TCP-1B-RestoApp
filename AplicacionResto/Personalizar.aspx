<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Personalizar.aspx.cs" Inherits="AplicacionResto.Personalizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid bg-dark text-white">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" data-bs-toggle="tab" aria-current="page" href="#registro">Crear usuario</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#configMesa">Configuracion de mesas</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#configMozo">Configuracion de mozos</a>
            </li>


        </ul>

        <div class="tab-content mt-3">
            <div class="tab-pane fade show active" id="registro" role="tabpanel" aria-labelledby="home-tab">


                <div class="row">

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
        <div class="tab-content mt-3">
            <div class="tab-pane fade" id="configMesa" role="tabpanel">
                <p>Contenido de la segunda pestaña.</p>
            </div>
        </div>
        <div class="tab-content mt-3">
            <div class="tab-pane fade" id="configMozo" role="tabpanel">
                <p>Contenido de la tercera pestaña.</p>
            </div>
        </div>
    </div>
</asp:Content>
