<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Personalizar.aspx.cs" Inherits="AplicacionResto.Personalizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container-fluid bg-dark text-white">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" data-bs-toggle="tab" aria-current="page" href="#mesas">Crear usuario</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" data-bs-toggle="tab" href="#mostrador">Configuracion de mesas</a>
            </li>


        </ul>

        <div class="tab-content mt-3">
            <div class="tab-pane fade show active" id="mesas" role="tabpanel" aria-labelledby="home-tab">


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
                <div class="col-4">

                <asp:TextBox runat="server" CssClass="form-control" ID="txtTipo" TextMode="Number"/>
                </div>
            </div>
            <asp:Button  Text="Registrar"  CssClass="btn btn-primary" ID="btnRegistrarse" onclick="btnRegistrarse_Click" runat="server"/>
            <a href="Pedidos.aspx">cancelar</a>


        </div>
    </div>




            </div>

            <div class="tab-pane fade" id="mostrador" role="tabpanel">
                <p>Contenido de la segunda pestaña.</p>
            </div>

            <div class="tab-pane fade" id="delivery" role="tabpanel">
                <label>Pendientes</label>
                <table class="table table-bordered border-primary">
                    <thead>
                        <tr>
                            <th scope="col">Num Pedido</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Descripcion</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Ramiro Blanco </td>
                            <td>Milanesa con papas fritas </td>
                        </tr>
                        <tr>
                            <th scope="row">2</th>
                            <td>Tomas Avalos</td>
                            <td>Canelones</td>
                        </tr>
                        <tr>
                            <th scope="row">3</th>
                            <td>Claudio Blanco</td>
                            <td>Hamburguesa</td>
                        </tr>
                    </tbody>
                </table>

                <label>En Preparacion</label>
                <table class="table table-bordered border-primary">
                    <thead>
                        <tr>
                            <th scope="col">Num Pedido</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Descripcion</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Ramiro Blanco </td>
                            <td>Milanesa con papas fritas </td>
                        </tr>
                        <tr>
                            <th scope="row">2</th>
                            <td>Tomas Avalos</td>
                            <td>Canelones</td>
                        </tr>
                        <tr>
                            <th scope="row">3</th>
                            <td>Claudio Blanco</td>
                            <td>Hamburguesa</td>
                        </tr>
                    </tbody>
                </table>


                <label>Pendientes</label>
                <table class="table table-bordered border-primary">
                    <thead>
                        <tr>
                            <th scope="col">Num Pedido</th>
                            <th scope="col">Nombre</th>
                            <th scope="col">Descripcion</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">1</th>
                            <td>Ramiro Blanco </td>
                            <td>Milanesa con papas fritas </td>
                        </tr>
                        <tr>
                            <th scope="row">2</th>
                            <td>Tomas Avalos</td>
                            <td>Canelones</td>
                        </tr>
                        <tr>
                            <th scope="row">3</th>
                            <td>Claudio Blanco</td>
                            <td>Hamburguesa</td>
                        </tr>
                    </tbody>
                </table>


            </div>
            <br />
        </div>
    </div>







</asp:Content>