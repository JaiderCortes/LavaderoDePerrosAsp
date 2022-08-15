<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cliente.aspx.vb" Inherits="Lavadero_de_perros.cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Don perro (Clientes)</title>
    <!--Google fonts-->
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Balsamiq+Sans&family=Noto+Sans&family=Poppins:wght@500&family=Roboto:wght@100&display=swap" rel="stylesheet" />
    <!--Font awesome-->
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.15.2/css/all.css" integrity="sha384-vSIIfh2YWi9wW0r9iZe7RJPrKwp6bG+s9QZMoITbCckVJqGCCRhc+ccxNcdpHuYu" crossorigin="anonymous" />

    <!--Bootstrap-->
    <!--CSS-->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous" />
    <!--JavaScript-->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.bundle.min.js" integrity="sha384-ygbV9kiqUc6oa4msXn9868pTtWMgiQaeYH7/t7LECLbyPA2x65Kgf80OJFdroafW" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js" integrity="sha384-q2kxQ16AaE6UbzuKqyBE9/u/KzioAlnx2maXQHiDX9d4/zp8Ok3f+M7DPm+Ib6IU" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.min.js" integrity="sha384-pQQkAEnwaBkjpqZ8RU1fF1AKtTcHJwFl3pblpTlHXybJjHpMYo79HY3hIi4NKxyj" crossorigin="anonymous"></script>

    <!--UIKit-->
    <!-- UIkit CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/uikit@3.6.18/dist/css/uikit.min.css" />

    <!-- UIkit JS -->
    <script src="https://cdn.jsdelivr.net/npm/uikit@3.6.18/dist/js/uikit.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/uikit@3.6.18/dist/js/uikit-icons.min.js"></script>

    <!--Estilos-->
    <link rel="stylesheet" type="text/css" href="estilos.css" />

    <!--Magia-->
    <script type="text/javascript" src="magia.js"></script>

    <!--Icon-->
    <link rel="icon" href="Iconos/cliente.ico" />
</head>
<body>
    <form id="form1" runat="server">
        <!--Encabezado-->
        <header class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow">
            <a href="main.aspx" class="navbar-brand col-md-3 col-lg-2 me-0 px-3">
                <font style="vertical-align: inherit">
                    <font style="vertical-align: inherit">Don perro</font>
                </font>
            </a>
            <button class="navbar-toggler position-absolute d-md-none collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#sidebarMenu" aria-controls="sidebarMenu" aria-expanded="false" aria-label="Navegación de palanca">
                <span class="navbar-toggler-icon"></span>
            </button>
            <input class="form-control form-control-dark w-100" type="text" placeholder="Buscar servicio" aria-label="Buscar" />
            <ul class="navbar-nav px-3">
                <li class="nav-item text-nowrap">
                    <a class="nav-link">
                        <font style="vertical-align: inherit">
                            <font style="vertical-align: inherit">Registrate</font>
                        </font>
                    </a>
                </li>
            </ul>
        </header>
        <!--Contenido-->
        <div class="container-fluid">
            <div class="row">
                <!--Inicio menú-->
                <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse">
                    <div class="position-sticky pt-3">
                        <ul class="nav flex-column">
                            <li class="nav-item">
                                <a class="nav-link" aria-current="page" href="main.aspx">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-house" viewBox="0 0 16 16">
                                        <path fill-rule="evenodd" d="M2 13.5V7h1v6.5a.5.5 0 0 0 .5.5h9a.5.5 0 0 0 .5-.5V7h1v6.5a1.5 1.5 0 0 1-1.5 1.5h-9A1.5 1.5 0 0 1 2 13.5zm11-11V6l-2-2V2.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5z" />
                                        <path fill-rule="evenodd" d="M7.293 1.5a1 1 0 0 1 1.414 0l6.647 6.646a.5.5 0 0 1-.708.708L8 2.207 1.354 8.854a.5.5 0 1 1-.708-.708L7.293 1.5z" />
                                    </svg>
                                    <font style="vertical-align: inherit">
                                        <font style="vertical-align: inherit">Inicio</font>
                                    </font>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link active" aria-current="page" href="cliente.aspx">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person" viewBox="0 0 16 16">
                                        <path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H3s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C11.516 10.68 10.289 10 8 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z" />
                                    </svg>
                                    <font style="vertical-align: inherit">
                                        <font style="vertical-align: inherit">Cliente</font>
                                    </font>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" aria-current="page" href="perro.aspx">
                                    <i class="fas fa-dog"></i>
                                    <font style="vertical-align: inherit">
                                        <font style="vertical-align: inherit">Perro</font>
                                    </font>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" aria-current="page" href="lavado.aspx">
                                    <i class="fas fa-soap"></i>
                                    <font style="vertical-align: inherit">
                                        <font style="vertical-align: inherit">Lavado</font>
                                    </font>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" aria-current="page" href="prod_lav.aspx">
                                    <i class="fas fa-shopping-bag"></i>
                                    <font style="vertical-align: inherit">
                                        <font style="vertical-align: inherit">Productos_lavado</font>
                                    </font>
                                    <i class="fas fa-bath"></i>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" aria-current="page" href="producto.aspx">
                                    <i class="fas fa-shopping-bag"></i>
                                    <font style="vertical-align: inherit">
                                        <font style="vertical-align: inherit">Producto</font>
                                    </font>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" aria-current="page" href="employee.aspx">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-bounding-box" viewBox="0 0 16 16">
                                        <path d="M1.5 1a.5.5 0 0 0-.5.5v3a.5.5 0 0 1-1 0v-3A1.5 1.5 0 0 1 1.5 0h3a.5.5 0 0 1 0 1h-3zM11 .5a.5.5 0 0 1 .5-.5h3A1.5 1.5 0 0 1 16 1.5v3a.5.5 0 0 1-1 0v-3a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 1-.5-.5zM.5 11a.5.5 0 0 1 .5.5v3a.5.5 0 0 0 .5.5h3a.5.5 0 0 1 0 1h-3A1.5 1.5 0 0 1 0 14.5v-3a.5.5 0 0 1 .5-.5zm15 0a.5.5 0 0 1 .5.5v3a1.5 1.5 0 0 1-1.5 1.5h-3a.5.5 0 0 1 0-1h3a.5.5 0 0 0 .5-.5v-3a.5.5 0 0 1 .5-.5z" />
                                        <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm8-9a3 3 0 1 1-6 0 3 3 0 0 1 6 0z" />
                                    </svg>
                                    <font style="vertical-align: inherit">
                                        <font style="vertical-align: inherit">Empleado</font>
                                    </font>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" aria-current="page" href="lav_emp.aspx">
                                    <i class="fas fa-bath"></i>
                                    <font style="vertical-align: inherit">
                                        <font style="vertical-align: inherit">Lavado_empleado</font>
                                    </font>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-bounding-box" viewBox="0 0 16 16">
                                        <path d="M1.5 1a.5.5 0 0 0-.5.5v3a.5.5 0 0 1-1 0v-3A1.5 1.5 0 0 1 1.5 0h3a.5.5 0 0 1 0 1h-3zM11 .5a.5.5 0 0 1 .5-.5h3A1.5 1.5 0 0 1 16 1.5v3a.5.5 0 0 1-1 0v-3a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 1-.5-.5zM.5 11a.5.5 0 0 1 .5.5v3a.5.5 0 0 0 .5.5h3a.5.5 0 0 1 0 1h-3A1.5 1.5 0 0 1 0 14.5v-3a.5.5 0 0 1 .5-.5zm15 0a.5.5 0 0 1 .5.5v3a1.5 1.5 0 0 1-1.5 1.5h-3a.5.5 0 0 1 0-1h3a.5.5 0 0 0 .5-.5v-3a.5.5 0 0 1 .5-.5z" />
                                        <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm8-9a3 3 0 1 1-6 0 3 3 0 0 1 6 0z" />
                                    </svg>
                                </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" aria-current="page" href="cubrimiento.aspx">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-x" viewBox="0 0 16 16">
                                        <path d="M6 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6zm2-3a2 2 0 1 1-4 0 2 2 0 0 1 4 0zm4 8c0 1-1 1-1 1H1s-1 0-1-1 1-4 6-4 6 3 6 4zm-1-.004c-.001-.246-.154-.986-.832-1.664C9.516 10.68 8.289 10 6 10c-2.29 0-3.516.68-4.168 1.332-.678.678-.83 1.418-.832 1.664h10z" />
                                        <path fill-rule="evenodd" d="M12.146 5.146a.5.5 0 0 1 .708 0L14 6.293l1.146-1.147a.5.5 0 0 1 .708.708L14.707 7l1.147 1.146a.5.5 0 0 1-.708.708L14 7.707l-1.146 1.147a.5.5 0 0 1-.708-.708L13.293 7l-1.147-1.146a.5.5 0 0 1 0-.708z" />
                                    </svg>
                                    <font style="vertical-align: inherit">
                                        <font style="vertical-align: inherit">Cubrimiento</font>
                                    </font>
                                </a>
                            </li>
                        </ul>
                        <hr />
                        <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                            <span>
                                <font style="vertical-align: inherit">
                                    <font style="vertical-align: inherit">Jaider Cortes 2021</font>
                                </font>
                            </span>
                        </h6>
                        <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                            <span>
                                <font style="vertical-align: inherit">
                                    <font style="vertical-align: inherit">Todos los derechos reservados</font>
                                </font>
                            </span>
                        </h6>
                        <a href="main.aspx">
                            <img src="Don perro.png" class="img-fluid img-thumbnail" width="200px" height="250px" style="margin-left: 15px" />
                        </a>
                    </div>
                </nav>
                <!--Fin menu-->

                <!--Inicio contenido-->
                <main class="col-md-9 ms-sm-auto col-lg-10 px-md-4">
                    <!--Content-->
                    <div class="align-items-center pt-3 pb-2 mb-3 border-bottom">
                        <h1 class="h2">Cliente</h1>
                        <p>
                            En esta página podrá hacer el manejo de la tabla Cliente, haciendo inserción, actualización y eliminación de datos.
                        </p>
                        <!--Cajas de texto-->
                        <div class="container">
                            <div class="row">
                                <div class="col col-text">
                                    Id:
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="idCli" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="col col-text">
                                    Nombre:
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="nomCli" runat="server" Enabled="true"> </asp:TextBox><asp:RequiredFieldValidator ID="reqNom" runat="server" ControlToValidate="nomCli" ErrorMessage="RequiredFieldValidator" ForeColor="red" CssClass="valid">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col col-text">
                                    Apellido:
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="apeCli" runat="server" Enabled="true"> </asp:TextBox><asp:RequiredFieldValidator ID="reqApe" runat="server" ControlToValidate="apeCli" ErrorMessage="RequiredFieldValidator" ForeColor="red" CssClass="valid">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="col col-text">
                                    Telefono:
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="telCli" runat="server" Enabled="true"> </asp:TextBox><asp:RequiredFieldValidator ID="reqTel" runat="server" ControlToValidate="telCli" ErrorMessage="RequiredFieldValidator" ForeColor="red" CssClass="valid">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col col-text">
                                    Dirección:
                                </div>
                                <div class="col">
                                    <asp:TextBox ID="dircli" runat="server" Enabled="true"> </asp:TextBox><asp:RequiredFieldValidator ID="reqDir" runat="server" ControlToValidate="dirCli" ErrorMessage="RequiredFieldValidator" ForeColor="red" CssClass="valid">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <!--Botones funciones-->
                        <div class="container">
                            <div class="row">
                                <div class="col v-center">
                                    <asp:Button ID="btnFirst" runat="server" Text="Primero" CssClass="btn d-block mx-auto btnF"/>
                                </div>
                                <div class="col v-center">
                                    <asp:Button ID="btnPrev" runat="server" Text="Anterior" CssClass="btn d-block mx-auto text-dark btnP"/>
                                </div>
                                <div class="col v-center">
                                    <asp:Button ID="btnNex" runat="server" Text="Siguiente" CssClass="btn d-block mx-auto text-dark btnN"/>
                                </div>
                                <div class="col v-center">
                                    <asp:Button ID="btnLast" runat="server" Text="Ultimo" CssClass="btn d-block mx-auto btnL"/>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col v-center">
                                    <asp:Button ID="btnNew" runat="server" Text="Nuevo" CssClass="btn d-block mx-auto btnNw"/>
                                </div>
                                <div class="col v-center">
                                    <asp:Button ID="btnIns" runat="server" Text="Insertar" CssClass="btn d-block mx-auto btnI" Enabled="false"/>
                                </div>
                                <div class="col v-center">
                                    <asp:Button ID="btnUpd" runat="server" Text="Actualizar" CssClass="btn d-block mx-auto btnU"/>
                                </div>
                                <div class="col v-center">
                                    <asp:Button ID="btnDel" runat="server" Text="Eliminar" CssClass="btn d-block mx-auto btnD"/>
                                </div>
                                <div class="col v-center">
                                    <asp:Button ID="btnCan" runat="server" Text="Cancelar" CssClass="btn d-block mx-auto btnC" Visible="False"/>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!--Sobre la página-->
                    <button class="uk-button uk-button-default botoninfo" type="button" uk-toggle="target: #infoPag">
                        <a href="" uk-icon="icon: info"></a>
                    </button>
                    <div id="infoPag" uk-offcanvas="flip: true; overlay: true">
                        <div class="uk-offcanvas-bar">
                            <button class="uk-offcanvas-close" type="button" uk-close></button>

                            <h3>Sobre esta página</h3>

                            <p>
                                Esta página fue diseñada con el fin de que la persona encargada de administrar el sitio web, que imagino que es usted, 
                            tenga la posibilidad de editar información de los clientes registrados en el sitio web de la empresa, de tal modo que se 
                            pueda llevar bien la información de la base de datos de la empresa.
                            </p>
                            <h6>Atentamente: administración de la página</h6>
                        </div>
                    </div>
                </main>
                <!--Fin contenido-->
            </div>
        </div>
    </form>

</body>
</html>
